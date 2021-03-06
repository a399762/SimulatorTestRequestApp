﻿using FileDialogFilterBuilder;
using Microsoft.EntityFrameworkCore;
using SimBridge.Database;
using SimBridge.Helpers;
using SimTestRequestBridge.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace SimTestRequestBridge.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //place in settings
        private string rootStagingPath = @"C:\Staging\";

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<TestRequest> testRequests = new ObservableCollection<TestRequest>();
        private ObservableCollection<TestRequest> completedTestRequests = new ObservableCollection<TestRequest>();
        private ObservableCollection<Step> currentWorkingTestRequestSteps = new ObservableCollection<Step>();

        private ObservableCollection<TireModelType> tireModelTypes = new ObservableCollection<TireModelType>();
        private ObservableCollection<Location> locations = new ObservableCollection<Location>();
        private ObservableCollection<Maneuver> maneuvers = new ObservableCollection<Maneuver>();
        private ObservableCollection<SpeedUnit> speedUnits = new ObservableCollection<SpeedUnit>();
        private ObservableCollection<StepStartingCondition> stepStartingConditions = new ObservableCollection<StepStartingCondition>();
        private ObservableCollection<LocationLapTimeConfigurationDRD> locationLapTimeConfigurationDRDs = new ObservableCollection<LocationLapTimeConfigurationDRD>();
        //one to keep track of what is selected that is loaded minimally, the other to actively modify, it has all the things in it....
        private TestRequest currentSelectedTestRequest;
        private TestRequest currentWorkingTestRequest;

        private Step currentTestRequestStep;
        private SimBridgeDataContext currentWorkingContext;

        public MainWindowViewModel()
        {
            this.CurrentWorkingTestRequestSteps = new ObservableCollection<Step>();

            //load the requests themselves
            LoadTestRequestsAsync();
        }

        public string GetCurrentTireTypeOpenDialogFilter()
        {
            var filterBuilder = new FileDialogFilterBuilder.FileDialogFilterBuilder();
            string[] fileExtensions = CurrentTestRequestStep.TireModelType.FileExtensionList.Trim().ToLower().Replace(".","").Split(',');

            filterBuilder.Infos.Add(new FilterInfo(CurrentTestRequestStep.TireModelType.Description, fileExtensions));
            return filterBuilder.ToFilterString();
        }
        public Task<bool> StageVehicleSendFileAsync(string filename)
        {
            return Task<bool>.Run(() => StageVehicleSendFile(filename));
        }
        public DirectoryInfo GetCurrentStagingFolder()
        {
            if (CurrentWorkingTestRequest != null)
                return FileHelper.GetStagingFolderForTestRequest(CurrentWorkingTestRequest.TestNumber, rootStagingPath);
            else
                return null;
        }
        public bool StageTireFilesForCurrentStep(List<string> filenames, TireLocationsCodes locationsCode)
        {
            if (CurrentWorkingTestRequest == null)
                return false;

            if (CurrentTestRequestStep == null)
                return false;

            switch (locationsCode)
            {
                case TireLocationsCodes.LF:
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep, currentTestRequestStep.LFTire, currentTestRequestStep.TireModelType.TireModelTypeID, filenames, TireLocationsCodes.LF);
                    break;
                case TireLocationsCodes.LR:
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep, currentTestRequestStep.LRTire, currentTestRequestStep.TireModelType.TireModelTypeID, filenames, TireLocationsCodes.LR);
                    break;
                case TireLocationsCodes.RF:
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep, currentTestRequestStep.RFTire, currentTestRequestStep.TireModelType.TireModelTypeID, filenames, TireLocationsCodes.RF);
                    break;
                case TireLocationsCodes.RR:
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep, currentTestRequestStep.RRTire, currentTestRequestStep.TireModelType.TireModelTypeID, filenames, TireLocationsCodes.RR);
                    break;
                case TireLocationsCodes.All:

                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep, currentTestRequestStep.LFTire, currentTestRequestStep.TireModelType.TireModelTypeID, filenames, TireLocationsCodes.LF);
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep, currentTestRequestStep.LRTire, currentTestRequestStep.TireModelType.TireModelTypeID, filenames, TireLocationsCodes.LR);
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep, currentTestRequestStep.RFTire, currentTestRequestStep.TireModelType.TireModelTypeID, filenames, TireLocationsCodes.RF);
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep, currentTestRequestStep.RRTire, currentTestRequestStep.TireModelType.TireModelTypeID, filenames, TireLocationsCodes.RR);

                    break;
                default:
                    return false;
            }

            return true;
        }
        public void ClearCurrentTestRequestMasterCar()
        {
            //clear object in db, and remove file

            string file = CurrentWorkingTestRequest.SendFilePath;

            if (File.Exists(file))
                File.Delete(file);
            
            CurrentWorkingTestRequest.SendFilePath = null;
        }
        public void ClearCurrentTestRequestCarCDB()
        {
            string file = CurrentWorkingTestRequest.CDBFilePath;

            if (File.Exists(file))
                File.Delete(file);

            CurrentWorkingTestRequest.CDBFilePath = null;
        }
        private bool StageSendFile(TestRequest testRequest, string filename)
        {
            //copy file to staging folder for test session
            string fileNameOnly = Path.GetFileName(filename);
            string newfileLocation = Path.Combine(FileHelper.GetOriginalSendFilesStagingFolderForTestRequest(testRequest.TestNumber, rootStagingPath).FullName, fileNameOnly);

            try
            {
                File.Copy(filename, newfileLocation, true);
                CurrentWorkingTestRequest.SendFilePath = newfileLocation;
                OnPropertyChanged(nameof(CurrentWorkingTestRequest));//notify that we just updated test request with send file info
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool ImportGttdTestRequest(string filename)
        {
            bool result = false;
            //using wrapped data object, import into db
            try
            {
                var content = File.ReadAllText(filename);
                var wrappedRequest = GttdTestRequestHelper.ConvertFromXMLToEntity(content);

                using (SimBridgeDataContext context = new SimBridgeDataContext())
                {
                    //try grab car from import
                    var selectedCar = context.Cars.FirstOrDefault(i => i.Description.CompareTo(wrappedRequest.VEHICLE_MODEL) == 0);

                    //do we have it?
                    if (selectedCar == null)
                        throw new Exception("Car Not Found");

                    TestRequest testRequest = new TestRequest();
                    testRequest.Car = selectedCar;
                    testRequest.TestCode = wrappedRequest.Test_Code;
                    testRequest.RecievedTime = DateTime.Now;
                    testRequest.TestNumber = wrappedRequest.Test_Number;
                    testRequest.TestCode = wrappedRequest.Test_Code;
                    testRequest.Steps = new List<Step>();
                    testRequest.MachineName = wrappedRequest.MACHINE_NAME;
                    testRequest.PreferDriver = wrappedRequest.PREFER_DRIVER;

                    foreach (var item in wrappedRequest.Steps)
                    {
                        Step tempStep = new Step();

                        tempStep.LFTire = new Tire();
                        tempStep.LFTire.Construction = item.LF_CONST;
                        tempStep.LFTire.Pressure = double.Parse(item.LF_INFLATION);
                        tempStep.LRTire = new Tire();
                        tempStep.LRTire.Construction = item.LR_CONST;
                        tempStep.LRTire.Pressure = double.Parse(item.LR_INFLATION);
                        tempStep.RFTire = new Tire();
                        tempStep.RFTire.Construction = item.RF_CONST;
                        tempStep.RFTire.Pressure = double.Parse(item.RF_INFLATION);
                        tempStep.RRTire = new Tire();
                        tempStep.RRTire.Construction = item.RR_CONST;
                        tempStep.RRTire.Pressure = double.Parse(item.RR_INFLATION);

                        var setTrackLocation = context.Locations.FirstOrDefault(i => i.Description.CompareTo(item.TRACK) == 0);
                        var setManuever = context.Maneuvers.FirstOrDefault(i => i.Description.CompareTo(item.MANEUVER) == 0);
                        var setTireModel = context.TireTypes.FirstOrDefault(i => i.Description.CompareTo(item.TIRE_MODEL) == 0);

                        //do we have it?
                        if (setTrackLocation == null)
                            throw new Exception("Track Location Not Found: " + item.TRACK);

                        if (setManuever == null)
                            throw new Exception("Manuever Not Found: " + item.MANEUVER);

                        if (setTireModel == null)
                            throw new Exception("Tire Model Not Found: " + item.TIRE_MODEL);

                        tempStep.StepLocation = setTrackLocation;
                        tempStep.StepManeuver = setManuever;
                        tempStep.TireModelType = setTireModel;
                        tempStep.InitSpeedUnit = context.SpeedUnits.FirstOrDefault();
                        tempStep.InitStepStartingCondition = context.StepStartingConditions.FirstOrDefault();
                        tempStep.StepNumber = int.Parse(item.Test_Step_Number);
                        testRequest.Steps.Add(tempStep);
                    }

                    context.TestRequests.Add(testRequest);

                    context.SaveChanges();
                    result = true;
                    LoadTestRequestsAsync();
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
          
            return result;
        }
        public bool StageVehicleCDB(string path)
        {
            if (CurrentWorkingTestRequest == null)
                return false;

            bool result = false;

            string rootCDBFolderName = new DirectoryInfo(path).Name;

            string testNumber = CurrentWorkingTestRequest.TestNumber;
            string cdbStagingPath = Path.Combine(FileHelper.GetStagingFolderForTestRequest(testNumber, rootStagingPath).FullName, rootCDBFolderName);

            try
            {
                DirectoryInfo source = new DirectoryInfo(path);
                DirectoryInfo target = new DirectoryInfo(cdbStagingPath);

                //copy all folders and files from filePath to the staging folder.
                FileHelper.CopyAll(source, target);
                CurrentWorkingTestRequest.CDBFilePath = target.FullName;
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        //clear staging folder, used during development,.. prolly not for prod
        public void ClearCurrentTestRequestStagingFolder()
        {
            DirectoryInfo di = GetCurrentStagingFolder();

            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                dir.Delete(true);
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = IsValid(sender as DependencyObject);
        }

        private bool IsValid(DependencyObject obj)
        {
            return !Validation.GetHasError(obj) && LogicalTreeHelper.GetChildren(obj).OfType<DependencyObject>().All(IsValid);
        }
        internal void ClearStepTire(TireLocationsCodes code)
        {
            switch (code)
            {
                case TireLocationsCodes.LF:
                    ClearStagedTireFiles(currentTestRequestStep.LFTire);
                    break;
                case TireLocationsCodes.LR:
                    ClearStagedTireFiles(currentTestRequestStep.LRTire);
                    break;
                case TireLocationsCodes.RF:
                    ClearStagedTireFiles(currentTestRequestStep.RFTire);
                    break;
                case TireLocationsCodes.RR:
                    ClearStagedTireFiles(currentTestRequestStep.RRTire);
                    break;
                case TireLocationsCodes.All:
                    //no button for this,.. just in case though
                    ClearStagedTireFiles(currentTestRequestStep.LFTire);
                    ClearStagedTireFiles(currentTestRequestStep.LRTire);
                    ClearStagedTireFiles(currentTestRequestStep.RFTire);
                    ClearStagedTireFiles(currentTestRequestStep.RRTire);
                    break;
                default:
                    break;
            }
        }
        private void ClearStagedTireFiles(Tire tire)
        {
            tire.TirePath = null;
            tire.CDT31TirePath = null;
        }
        private bool StageTireFiles(string testRequestID, Step step, Tire tire, int tireTypeID, List<string> filenames, TireLocationsCodes tireLocationsCode)
        {

            var tirFilePath = filenames.FirstOrDefault(i => i.Contains(".tir"));
            var cdtFilePath = filenames.FirstOrDefault(i => i.Contains(".cdt31"));

            string tirFileName = Path.GetFileName(tirFilePath);
            string cdtFileName = Path.GetFileName(cdtFilePath);

            string newtirFilePath = FileHelper.GetTiresStagingFolderForTestRequest(testRequestID, step.StepNumber, tireLocationsCode, rootStagingPath) + @"\" + tirFileName;
            string newcdtFilePath = FileHelper.GetTiresStagingFolderForTestRequest(testRequestID, step.StepNumber, tireLocationsCode, rootStagingPath) + @"\" + cdtFileName;

            bool result = false;
            //do special things depending on type
            switch (tireTypeID)
            {
                case (int)TireModelTypesEnum.CDTire:

                    if (tirFilePath == null || cdtFilePath == null)
                        return false;

                    try
                    {
                        File.Copy(tirFilePath, newtirFilePath, true);
                        File.Copy(cdtFilePath, newcdtFilePath, true);

                        //if we are ok file wise, this will work next.
                        tire.TirePath = newtirFilePath;
                        tire.CDT31TirePath = newcdtFilePath;
                        result = true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    break;
                case (int)TireModelTypesEnum.MFSwift:
                case (int)TireModelTypesEnum.MFTire:
                    if (tirFilePath == null)
                        return false;

                    try
                    {
                        File.Copy(tirFilePath, newtirFilePath, true);

                        //if we are ok file wise, this will work next.
                        tire.TirePath = newtirFilePath;
                        result = true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;

                default:
                    result = false;
                    break;
            }

            return result;
        }
        private bool StageVehicleSendFile(string filename)
        {
            bool result = false;
            if (CurrentWorkingTestRequest != null)
            {
                if (!StageSendFile(CurrentWorkingTestRequest, filename))
                    return false;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// check that all information is filled out in the step, i.e. All tires are entered into 
        /// </summary>
        /// <param name="currentTestRequestStep"></param>
        /// <returns></returns>
        internal bool ValidateTestRequestForStep(Step currentTestRequestStep)
        {
            //check to make sure each tire has a tire path, and that we have a valid base send file path loaded 
            if (CurrentWorkingTestRequest.SendFilePath != null && currentTestRequestStep.LFTire.TirePath != null &&
                currentTestRequestStep.LRTire.TirePath != null && currentTestRequestStep.RRTire.TirePath != null &&
                currentTestRequestStep.RFTire.TirePath != null)
            {
                return true;
            }

            return false;
        }
        public bool ValidateTestRequestStep
        {
            get
            {
                if (currentTestRequestStep != null && currentSelectedTestRequest != null)
                    return ValidateTestRequestForStep(currentTestRequestStep);
                else
                    return false;
            }
        }
        public bool ValidateTestRequestSteps
        {
            get
            {
                if (currentWorkingTestRequest != null && currentWorkingTestRequest.Steps != null)
                {
                    bool result = true;

                    foreach (var item in currentWorkingTestRequest.Steps)
                    {
                        if (!ValidateTestRequestForStep(item))
                            result = false;
                    }

                    return result;
                }
                else
                    return false;
            }
        }
        //load combobox choices and stuff...
        private void LoadAll()
        {
            if (currentWorkingContext != null)
            {
                var tiretypes = currentWorkingContext.TireTypes.ToList();
                if (tiretypes != null)
                    TireModelTypes = new ObservableCollection<TireModelType>(tiretypes);
                else
                    TireModelTypes = new ObservableCollection<TireModelType>();

                var speedUnits = currentWorkingContext.SpeedUnits.ToList();
                if (speedUnits != null)
                    SpeedUnits = new ObservableCollection<SpeedUnit>(speedUnits);
                else
                    SpeedUnits = new ObservableCollection<SpeedUnit>();

                var locations = currentWorkingContext.Locations.ToList();
                if (locations != null)
                    Locations = new ObservableCollection<Location>(locations);
                else
                    Locations = new ObservableCollection<Location>();

                var maneuvers = currentWorkingContext.Maneuvers.ToList();
                if (maneuvers != null)
                    Maneuvers = new ObservableCollection<Maneuver>(maneuvers);
                else
                    Maneuvers = new ObservableCollection<Maneuver>();

                var startingContitions = currentWorkingContext.StepStartingConditions.ToList();
                if (startingContitions != null)
                    StepStartingConditions = new ObservableCollection<StepStartingCondition>(startingContitions);
                else
                    StepStartingConditions = new ObservableCollection<StepStartingCondition>();
            }
        }
        public Task LoadTestRequestsAsync()
        {
            return Task.Run(() => LoadTestRequests());
        }
        private void LoadTestRequests()
        {
            using (SimBridgeDataContext context = new SimBridgeDataContext())
            {
                var allTestRequests = DBHelper.GetTestRequests(context);

                if (allTestRequests != null)
                    TestRequests = new ObservableCollection<TestRequest>(allTestRequests);
            }
        }
      
        //buttons
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new CommandHandler(() => SaveCurrentTestRequest(), () => CanExecute));
            }
        }
        public void SaveCurrentTestRequest()
        {
            try
            {
                if (currentWorkingContext != null)
                    currentWorkingContext.SaveChanges();
            }
            catch (Exception)
            {
           
            }
        }
        private void LoadTestRequest(int testRequestID)
        {
            try
            {
                currentWorkingContext = new SimBridgeDataContext();

                //load current context tracked entities into comboboxes, this allows us to drop them in place when user interacts.
                //as they are in the same context.
                LoadAll();

                //we will work out of this entity, and save its progress as things change.
                CurrentWorkingTestRequest = DBHelper.GetTestRequest(currentWorkingContext, testRequestID);
                
                //this holds the steps, allowing to UI interaction
                CurrentWorkingTestRequestSteps = new ObservableCollection<Step>(CurrentWorkingTestRequest.Steps);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //put this in a class function.. ftp related??/
        private bool StageCurrentSession()
        {
            try
            {
                //send all files from test request stage folder to simulator over ftp
                //catch errors.....


                IEnumerable<string> files = Directory.EnumerateFiles(GetCurrentStagingFolder().FullName);

                //using (WebClient client = new WebClient())
                //{
                //    client.Credentials = new NetworkCredential("username", "password");

                //    foreach (string file in files)
                //    {
                //        string remoteTestSessionPath = GetCurrentRemoteStagingFolderForTestRequest();
                //        client.UploadFile("ftp://example.com/remote/folder/" + Path.GetFileName(file), file);
                //    }
                //}
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        private string GetCurrentRemoteStagingFolderForTestRequest()
        {
            return GetRemoteStagingFolderForTestRequest(currentWorkingTestRequest.TestNumber);
        }
        private string GetRemoteStagingFolderForTestRequest(string testRequestID)
        {
            string path = "/vigrade/vicrt/";
            return path + testRequestID;
        }
        private void GenerateSendFileForCurrentStep()
        {
            GenerateSendFileForStep(CurrentTestRequestStep.StepID);
        }
        private void GenerateAllTestRequestSendFiles()
        {
            GenerateSendFilesForTestRequest(CurrentWorkingTestRequest);
        }
        private void GenerateSendFilesForTestRequest(TestRequest currentWorkingTestRequest)
        {
            //loop through each step and send to generate send file for step.
            foreach (var item in currentWorkingTestRequest.Steps)
            {
                GenerateSendFileForStep(item.StepID);
            }
        }
        private void GenerateSendFileForStep(int stepID)
        {
            Step step = currentWorkingContext.Steps.FirstOrDefault(i => i.StepID == stepID);
            var trID = step.TestRequestID;

            TestRequest testRequest = currentWorkingContext.TestRequests.FirstOrDefault(i => i.TestRequestID == trID);

            //grab current send file
            var originalSendFile = testRequest.SendFilePath;
            String rawSendFileXML = File.ReadAllText(originalSendFile);
            XDocument doc = XDocument.Parse(rawSendFileXML);

            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.fl_tire_property_file, ConvertToTiresMDISFormat(step.LFTire.TirePath), doc);
            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.rl_tire_property_file, ConvertToTiresMDISFormat(step.LRTire.TirePath), doc);
            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.fr_tire_property_file, ConvertToTiresMDISFormat(step.RFTire.TirePath), doc);
            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.rr_tire_property_file, ConvertToTiresMDISFormat(step.RRTire.TirePath), doc);

            StepStartingCondition tempStartingCondition;
            if (step.OverrideStartingCondition)
            {
                tempStartingCondition = new StepStartingCondition();
                tempStartingCondition.InitPositionX = step.InitPositionX;
                tempStartingCondition.InitPositionY = step.InitPositionX;
                tempStartingCondition.InitPositionZ = step.InitPositionX;
            }
            else
            {
                tempStartingCondition = step.InitStepStartingCondition;
            }

            SendFileHelper.SetStartingPosition(SendFileHelper.VehiclUserLocation.vehicle_user_location_x, tempStartingCondition.InitPositionX, doc);
            SendFileHelper.SetStartingPosition(SendFileHelper.VehiclUserLocation.vehicle_user_location_y, tempStartingCondition.InitPositionY, doc);
            SendFileHelper.SetStartingPosition(SendFileHelper.VehiclUserLocation.vehicle_user_location_z, tempStartingCondition.InitPositionZ, doc);
            SendFileHelper.SetStartingPosition(SendFileHelper.VehiclUserLocation.vehicle_user_location_roll, tempStartingCondition.InitPositionRX, doc);
            SendFileHelper.SetStartingPosition(SendFileHelper.VehiclUserLocation.vehicle_user_location_pitch, tempStartingCondition.InitPositionRY, doc);
            SendFileHelper.SetStartingPosition(SendFileHelper.VehiclUserLocation.vehicle_user_location_yaw, tempStartingCondition.InitPositionRZ, doc);

            DirectoryInfo directoryInfo = FileHelper.GetSendFilesStagingFolderForTestRequest(testRequest.TestNumber, rootStagingPath);
            string stepFileName = step.StepNumber + "_" + step.LFTire.Construction + "_" + step.RFTire.Construction + "_" + step.LRTire.Construction + "_" + step.RRTire.Construction + ".xml";

            //where do we want to save...
            string stepSendFilePath = Path.Combine(directoryInfo.FullName, stepFileName);

            //check to see if we have a vicrtcdb.cfg made yet
            //create if not

            string cdbFileName = Path.GetFileName(testRequest.CDBFilePath);

            FileHelper.CreateVICRTCDBCFG(cdbFileName, testRequest.TestNumber, rootStagingPath);

            //open init file.
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Resources\";
            string userEventVDFFilePath = folder + @"user_event.vdf";

            //Step_x_user_event.vdf"
            string stepVDFFileName = String.Format("Step_{0}_user_event.vdf",step.StepNumber);
            string stepVDFFilePath = FileHelper.GetVDFStagingFolderForTestRequest(testRequest.TestNumber, rootStagingPath) + @"\" + stepVDFFileName;

            //does master exist in resources dir?
            if (File.Exists(userEventVDFFilePath))
            {
                //modify it and save a copy for this step.
                var configLines = File.ReadAllText(userEventVDFFilePath);
                configLines = configLines.Replace("{0}", tempStartingCondition.InitSpeed.ToString());
                configLines = configLines.Replace("{1}", tempStartingCondition.InitGear.ToString());

                //save new file
                File.WriteAllText(stepVDFFilePath, configLines);
            }

            SendFileHelper.SetVDFPath("mdids://carrealtime_shared/driver_controls.tbl/user_event.vdf", doc);

            doc.Save(stepSendFilePath);
        }
        private string ConvertToVDFMDISFormat(string tirePath)
        {
            //grab file name 
            string tireFileName = Path.GetFileName(tirePath);

            //append it to the tire mdis target, cfg will tell vi where to find it on the HD
            string value = "mdids://SendFiles/" + tireFileName;
            return value;
        }
        private string ConvertToTiresMDISFormat(string tirePath)
        {
            //grab file name 
            string tireFileName = Path.GetFileName(tirePath);

            //append it to the tire mdis target, cfg will tell vi where to find it on the HD
            string value = "mdids://Tires/" + tireFileName;
            return value;
        }
        private void AddNewStepToCurrentTestRequest()
        {
            if (currentWorkingTestRequest != null )
            {
                Tire lf = new Tire();
                lf.Construction = "40930dpo";
                lf.Pressure = 31;
   
                Tire rf = new Tire();
                rf.Construction = "40930dpo";
                rf.Pressure = 31;
         
                Tire rr = new Tire();
                rr.Construction = "20930dpo";
                rr.Pressure = 32;

                Tire lr = new Tire();
                lr.Construction = "20930dpo";
                lr.Pressure = 33;
              
                Step step = new Step();
                step.GeneratedStepSendFilePath = "testpath";
                step.LFTire = lf;
                step.RFTire = rf;
                step.RRTire = rr;
                step.LRTire = lr;


                step.EnableAutomaticLapTimer = true;
                step.SteplocationLapTimeConfigurationDRD = null;
                step.TireModelType = currentWorkingContext.TireTypes.FirstOrDefault();
                step.InitStepStartingCondition = currentWorkingContext.StepStartingConditions.FirstOrDefault();
                step.StepLocation = currentWorkingContext.Locations.FirstOrDefault();
                step.StepManeuver = currentWorkingContext.Maneuvers.FirstOrDefault();
                step.InitSpeedUnit = currentWorkingContext.SpeedUnits.FirstOrDefault();
                
                //get next number to use based on existing - 1 based
                var newNumber = currentWorkingTestRequestSteps.Count() + 1;
                step.StepNumber = newNumber;

                CurrentWorkingTestRequest.Steps.Add(step);
                currentWorkingTestRequestSteps.Add(step);
                SaveCurrentTestRequest();
            }
        }
        private void MoveAndUpdateOrder(ICollection<Step> list, Step item, int positionToInsert)
        {
            if (positionToInsert > 0)
            {
                if (positionToInsert > list.Count)
                    return;

                // Order elements
                var ordered_list = list.OrderBy(a => a.StepNumber).ToList();

                // Remove and insert at the proper position
                ordered_list.Remove(item);
                ordered_list.Insert(positionToInsert - 1, item);

                // Update the Order properties according to it's current index +1
                for (int i = 0; i < ordered_list.Count; i++)
                    ordered_list[i].StepNumber = i + 1;
            }
        }
      
        private ICommand _deleteTestRequestStepCommand;
        public ICommand DeleteTestRequestStepCommand
        {
            get
            {
                return _deleteTestRequestStepCommand ?? (_deleteTestRequestStepCommand = new CommandHandler(() => DeleteSelectedStep(), () => CanExecute));
            }
        }
        private ICommand _deleteTestRequestCommand;
        public ICommand DeleteTestRequestCommand
        {
            get
            {
                return _deleteTestRequestCommand ?? (_deleteTestRequestCommand = new CommandHandler(() => DeleteSelectedTestRequest(), () => CanExecute));
            }
        }
        private void DeleteSelectedTestRequest()
        {
            var testRequest = currentSelectedTestRequest;

          //  currentWorkingTestRequestSteps.Remove(testRequest);
            //currentWorkingContext.Remove(step);
            //currentWorkingTestRequest.Steps.Remove(step);
        }
        private void DeleteSelectedStep()
        {
            var step = currentTestRequestStep;

            currentWorkingTestRequestSteps.Remove(step);
            currentWorkingContext.Remove(step);
            currentWorkingTestRequest.Steps.Remove(step);

            //re number each step 
            var ordered_list = currentWorkingTestRequest.Steps.OrderBy(a => a.StepNumber).ToList();
            for (int i = 0; i < ordered_list.Count; i++)
                ordered_list[i].StepNumber = i + 1;

            SaveCurrentTestRequest();
        }
        private ICommand _orderStepUpCommand;
        public ICommand OrderStepUpCommand
        {
            get
            {
                return _orderStepUpCommand ?? (_orderStepUpCommand = new CommandHandler(() => OrderSelectedStepUp(), () => CanExecute));
            }
        }
        private ICommand _orderStepDownCommand;
        public ICommand OrderStepDownCommand
        {
            get
            {
                return _orderStepDownCommand ?? (_orderStepDownCommand = new CommandHandler(() => OrderSelectedStepDown(), () => CanExecute));
            }
        }
        public void OrderSelectedStepUp()
        {
            MoveAndUpdateOrder(currentWorkingTestRequest.Steps, currentTestRequestStep, currentTestRequestStep.StepNumber - 1);
        }   
        public void OrderSelectedStepDown()
        {
            MoveAndUpdateOrder(currentWorkingTestRequest.Steps, currentTestRequestStep, currentTestRequestStep.StepNumber + 1);
        }

        //ICommand button callbacks
        private ICommand _generateSendFileCommand;
        public ICommand GenerateSendFileCommand
        {
            get
            {
                return _generateSendFileCommand ?? (_generateSendFileCommand = new CommandHandler(() => GenerateSendFileForCurrentStep(), () => ValidateTestRequestStep));
            }
        }
        private ICommand _generateAllTestRequestsSendFiles;
        public ICommand GenerateAllTestRequestsSendFiles
        {
            get
            {
                return _generateAllTestRequestsSendFiles ?? (_generateAllTestRequestsSendFiles = new CommandHandler(() => GenerateAllTestRequestSendFiles(), () => ValidateTestRequestSteps));
            }
        }
        private ICommand _newStepCommand;
        public ICommand NewStepCommand
        {
            get
            {
                return _newStepCommand ?? (_newStepCommand = new CommandHandler(() => AddNewStepToCurrentTestRequest(), () => CanExecute));
            }
        }
        private ICommand _stageCommand;
        public ICommand StageCommand
        {
            get
            {
                return _stageCommand ?? (_stageCommand = new CommandHandler(() => StageCurrentSession(), () => CanExecute));
            }
        }
        private ICommand _newCommand;
        public ICommand NewCommand
        {
            get
            {
                return _newCommand ?? (_newCommand = new CommandHandler(() => testGenerateNewTestRequest(), () => CanExecute));
            }
        }
        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new CommandHandler(() => LoadTestRequestsAsync(), () => CanExecute));
            }
        }
        public bool CanExecute
        {
            get
            {
                return true;
            }
        }
        public bool WorkingContextHasChanges
        {
            get
            {
                return currentWorkingContext.ChangeTracker.Entries().Any(e => e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted);
            }
        }

        public void testGenerateNewTestRequest()
        {
            //check if there is a car use first, else create then use
            try
            {
                using (SimBridgeDataContext context = new SimBridgeDataContext())
                {
                    var car = DBHelper.GetCars(context)[0];

                    TestRequest testRequest = new TestRequest();
                    testRequest.Car = car;
                    testRequest.Description = "test";
                    testRequest.RecievedTime = DateTime.Now;
                    testRequest.TestNumber = Guid.NewGuid().ToString().Substring(18);

                    TestRequests.Add(testRequest);

                    context.TestRequests.Add(testRequest);

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
            
            }
        }
        public ObservableCollection<Location> Locations
        {
            get
            {
                return locations;
            }
            set
            {
                locations = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<StepStartingCondition> StepStartingConditions
        {
            get
            {
                return stepStartingConditions;
            }
            set
            {
                stepStartingConditions = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<LocationLapTimeConfigurationDRD> LocationLapTimeConfigurationDRDs
        {
            get
            {
                return locationLapTimeConfigurationDRDs;
            }
            set
            {
                locationLapTimeConfigurationDRDs = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Maneuver> Maneuvers
        {
            get
            {
                return maneuvers;
            }
            set
            {
                maneuvers = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TireModelType> TireModelTypes
        {
            get { return tireModelTypes; }
            set
            {
                tireModelTypes = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<SpeedUnit> SpeedUnits
        {
            get { return speedUnits; }
            set
            {
                speedUnits = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TestRequest> TestRequests
        {
            get { return testRequests; }
            set
            {
                testRequests = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Step> CurrentWorkingTestRequestSteps
        {
            get { return currentWorkingTestRequestSteps; }
            set
            {
                currentWorkingTestRequestSteps = value;
                OnPropertyChanged();
            }
        }
        public TestRequest CurrentSelectedTestRequest
        {
            get { return currentSelectedTestRequest; }
            set
            {
                currentSelectedTestRequest = value;

                try
                {
                    if (currentSelectedTestRequest != null)
                        LoadTestRequest(currentSelectedTestRequest.TestRequestID);
                    else
                        CurrentWorkingTestRequest = null;
                }
                catch (Exception)
                {

                }

                OnPropertyChanged();
            }
        }
        public TestRequest CurrentWorkingTestRequest
        {
            get { return currentWorkingTestRequest; }
            set
            {
                if(currentWorkingTestRequest != null)
                    currentWorkingTestRequest.PropertyChanged -= PropertyChanged_Save;

                currentWorkingTestRequest = value;

                if (currentWorkingTestRequest != null)
                    currentWorkingTestRequest.PropertyChanged += PropertyChanged_Save;

                OnPropertyChanged();
            }
        }
        private void PropertyChanged_Save(object sender, PropertyChangedEventArgs e)
        {
            SaveCurrentTestRequest();

            //someone just changed the tiremodel type,
            //clear all linked tire files from entity as they are for the other tire type.
            //let file stay in place, but we wont be linking to it in the future,..may want to delete in future??
            if (e.PropertyName.CompareTo(typeof(TireModelType).Name) == 0)
            {
                ClearStagedTireFiles(currentTestRequestStep.LFTire);
                ClearStagedTireFiles(currentTestRequestStep.LRTire);
                ClearStagedTireFiles(currentTestRequestStep.RFTire);
                ClearStagedTireFiles(currentTestRequestStep.RRTire);
            }
        }
        public Step CurrentTestRequestStep
        {
            get { return currentTestRequestStep; }
            set
            {
                //remove old listeners
                if (currentTestRequestStep != null)
                {
                    currentTestRequestStep.PropertyChanged -= PropertyChanged_Save;
                    currentTestRequestStep.LFTire.PropertyChanged -= PropertyChanged_Save;
                    currentTestRequestStep.LRTire.PropertyChanged -= PropertyChanged_Save;
                    currentTestRequestStep.RFTire.PropertyChanged -= PropertyChanged_Save;
                    currentTestRequestStep.RRTire.PropertyChanged -= PropertyChanged_Save;
                }

                currentTestRequestStep = value;

                //setup new listeners, listen for change,.. so we can save progress
                if (currentTestRequestStep != null)
                {
                    currentTestRequestStep.PropertyChanged += PropertyChanged_Save;
                    currentTestRequestStep.LFTire.PropertyChanged += PropertyChanged_Save;
                    currentTestRequestStep.LRTire.PropertyChanged += PropertyChanged_Save;
                    currentTestRequestStep.RFTire.PropertyChanged += PropertyChanged_Save;
                    currentTestRequestStep.RRTire.PropertyChanged += PropertyChanged_Save;
                }

                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
