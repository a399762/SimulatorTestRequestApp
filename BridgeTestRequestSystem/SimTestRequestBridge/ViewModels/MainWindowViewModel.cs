using Microsoft.EntityFrameworkCore;
using SimBridge.Database;
using SimBridge.Helpers;
using SimTestRequestBridge.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace SimTestRequestBridge.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //place in settings
        private string stagingPath = @"C:\Staging";

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

        public Task<bool> StageVehicleSendFileAsync(string filename)
        {
            return Task<bool>.Run(() => StageVehicleSendFile(filename));
        }

        public string GetCurrentStagingFolder()
        {
            if (CurrentWorkingTestRequest != null)
                return FileHelper.GetStagingFolderForTestRequest(CurrentWorkingTestRequest.TestNumber,stagingPath);
            else
               return null;
        }

        internal bool StageTireFilesForCurrentStep(List<string> filenames, TireLocationsCodes locationsCode)
        {
            if (CurrentWorkingTestRequest == null)
                return false;

            if (CurrentTestRequestStep == null)
                return false;

            if (!FileHelper.CreateStagingFolderIfNotExist(CurrentWorkingTestRequest.TestNumber, stagingPath))
                return false;

            //grab the correct tire to work on.
            Tire tire;
            switch (locationsCode)
            {
                case TireLocationsCodes.FL:
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep.FLTire, currentTestRequestStep.TireModelTypeID, filenames);  
                    break;
                case TireLocationsCodes.FR:
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep.FRTire, currentTestRequestStep.TireModelTypeID, filenames);
                    break;
                case TireLocationsCodes.RL:
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep.RLTire, currentTestRequestStep.TireModelTypeID, filenames);
                    break;
                case TireLocationsCodes.RR:
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep.RRTire, currentTestRequestStep.TireModelTypeID, filenames);
                    break;
                case TireLocationsCodes.All:

                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep.RLTire, currentTestRequestStep.TireModelTypeID, filenames);
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep.FLTire, currentTestRequestStep.TireModelTypeID, filenames);
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep.FRTire, currentTestRequestStep.TireModelTypeID, filenames);
                    StageTireFiles(CurrentWorkingTestRequest.TestNumber, currentTestRequestStep.RRTire, currentTestRequestStep.TireModelTypeID, filenames);

                    break;
                default:
                    return false;
            }

            OnPropertyChanged(nameof(CurrentWorkingTestRequest));//notify that we just updated test request with send file info
            return true;
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
                case TireLocationsCodes.FL:
                    ClearStagedTireFiles(currentTestRequestStep.FLTire);
                    break;
                case TireLocationsCodes.FR:
                    ClearStagedTireFiles(currentTestRequestStep.FRTire);
                    break;
                case TireLocationsCodes.RL:
                    ClearStagedTireFiles(currentTestRequestStep.RLTire);
                    break;
                case TireLocationsCodes.RR:
                    ClearStagedTireFiles(currentTestRequestStep.RRTire);
                    break;
                case TireLocationsCodes.All:
                    //no button for this,.. just in case though
                    ClearStagedTireFiles(currentTestRequestStep.FLTire);
                    ClearStagedTireFiles(currentTestRequestStep.FRTire);
                    ClearStagedTireFiles(currentTestRequestStep.RLTire);
                    ClearStagedTireFiles(currentTestRequestStep.RRTire);
                    break;
                default:
                    break;
            }

            OnPropertyChanged(nameof(CurrentWorkingTestRequest));//notify that we just updated test request with send file info
        }

        private void ClearStagedTireFiles( Tire tire)
        {
            tire.TirePath = null;
            tire.CDT31TirePath = null;
        }

        private bool StageTireFiles(string testRequestID, Tire tire,int tireTypeID,List<string> filenames)
        {

            var tirFilePath = filenames.FirstOrDefault(i => i.Contains(".tir"));
            var cdtFilePath = filenames.FirstOrDefault(i => i.Contains(".cdt31"));

            string tirFileName = Path.GetFileName(tirFilePath);
            string cdtFileName = Path.GetFileName(cdtFilePath);

            string newtirFilePath = FileHelper.GetTiresStagingFolderForTestRequest(testRequestID, stagingPath) + @"\" + tirFileName;
            string newcdtFilePath = FileHelper.GetTiresStagingFolderForTestRequest(testRequestID, stagingPath) + @"\" + cdtFileName;

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
                    catch (Exception e)
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
                    catch (Exception e)
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
        internal bool ValidateTestRequestForStep(Step currentTestRequestStep, TestRequest currentSelectedTestRequest)
        {
            //check to make sure each tire has a tire path, and that we have a valid base send file path loaded 
            if (CurrentWorkingTestRequest.SendFilePath != null && currentTestRequestStep.FLTire.TirePath != null && 
                currentTestRequestStep.RLTire.TirePath != null && currentTestRequestStep.RRTire.TirePath != null && 
                currentTestRequestStep.FRTire.TirePath != null)
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
                    return ValidateTestRequestForStep(currentTestRequestStep, currentSelectedTestRequest);
                else
                    return false;
            }
        }

   

        private bool StageSendFile(TestRequest testRequest, string filename)
        {
            //copy file to staging folder for test session
            string fileNameOnly = Path.GetFileName(filename);
            string newfileLocation = FileHelper.GetSendFilesStagingFolderForTestRequest(testRequest.TestNumber,stagingPath) + @"\" + fileNameOnly;
            
            try
            {
                File.Copy(filename, newfileLocation,true);
                CurrentWorkingTestRequest.SendFilePath = newfileLocation;
                OnPropertyChanged(nameof(CurrentWorkingTestRequest));//notify that we just updated test request with send file info
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }


        //load combobox choices and stuff...
        private void LoadAll()
        {

            //  using (SimBridgeDataContext context = new SimBridgeDataContext())
            // {

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
          
         //   }
        }


        public Task CreateIfNotExistStaging(string testNumber, string stagingPath)
        {
            return Task.Run(() => FileHelper.CreateStagingFolderIfNotExist(testNumber, stagingPath));
        }

        private void LoadLocations()
        {
            using (SimBridgeDataContext context = new SimBridgeDataContext())
            {
                var locations = context.Locations.ToList();

                if (locations != null)
                    Locations = new ObservableCollection<Location>(locations);
            }
        }

        private void LoadManeuvers()
        {
            using (SimBridgeDataContext context = new SimBridgeDataContext())
            {
                var maneuvers = context.Maneuvers.ToList();

                if (maneuvers != null)
                    Maneuvers = new ObservableCollection<Maneuver>(maneuvers);
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
                return _saveCommand ?? (_saveCommand = new CommandHandler(() => saveCurrentTestRequest(), () => CanExecute));
            }
        }

        private void saveCurrentTestRequest()
        {
            try
            {
                currentWorkingContext.SaveChanges();
            }
            catch (Exception e)
            {
                string g = "";
            }
        }

        private async void LoadTestRequest(int testRequestID)
        {
            try
            {
                currentWorkingContext = new SimBridgeDataContext();

                //load current context tracked entities into comboboxes
                LoadAll();

                CurrentWorkingTestRequest = DBHelper.GetTestRequest(currentWorkingContext, testRequestID);
                CurrentWorkingTestRequestSteps = new ObservableCollection<Step>(CurrentWorkingTestRequest.Steps);

                //create staging folder async
                await CreateIfNotExistStaging(CurrentWorkingTestRequest.TestNumber, stagingPath);
            }
            catch (Exception err)
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
                IEnumerable<string> files = Directory.EnumerateFiles(GetCurrentStagingFolder());

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
            catch (Exception err)
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

            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.fl_tire_property_file, ConvertToMDISFormat(step.FLTire.TirePath), doc);
            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.fr_tire_property_file, ConvertToMDISFormat(step.FLTire.TirePath), doc);
            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.rl_tire_property_file, ConvertToMDISFormat(step.FLTire.TirePath), doc);
            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.rr_tire_property_file, ConvertToMDISFormat(step.FLTire.TirePath), doc);

            //place it next to the original send file for now
            var path = Path.GetDirectoryName(originalSendFile);

            //where do we want to save...
            var stepSendFilePath = FileHelper.GetSendFilesStagingFolderForTestRequest(testRequest.TestNumber, stagingPath) + @"\" + step + "_" + testRequest.Car.Description + "_" + step.LocationID + "_" + step.FLTire.Construction + "_" + step.FRTire.Construction + "_" + step.RLTire.Construction + "_" + step.RRTire.Construction + ".xml";
            doc.Save(stepSendFilePath);
        }

        private string ConvertToMDISFormat(string tirePath)
        {




            return tirePath;
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
                step.FLTire = lf;
                step.FRTire = rf;
                step.RRTire = rr;
                step.RLTire = lr;


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
            }
        }

        void MoveAndUpdateOrder(ICollection<Step> list, Step item, int positionToInsert)
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
                return _deleteTestRequestCommand ?? (_deleteTestRequestCommand = new CommandHandler(() => DeleteSelectedTestRequest(), () => ValidateTestRequestStep));
            }
        }

        private void DeleteSelectedTestRequest()
        {
            throw new NotImplementedException();
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

        
    private ICommand _generateAllTestRequestsSendFileCommand;
        public ICommand GenerateAllTestRequestsSendFileCommand
        {
            get
            {
                return _generateAllTestRequestsSendFileCommand ?? (_generateAllTestRequestsSendFileCommand = new CommandHandler(() => GenerateAllTestRequestSendFiles(), () => CanExecute));
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
            catch (Exception ee)
            {
                string t = "";
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


        public ObservableCollection<TestRequest> CompletedTestRequests
        {
            get { return completedTestRequests; }
            set
            {
                completedTestRequests = value;
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
                catch (Exception err)
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
                currentWorkingTestRequest = value;
                OnPropertyChanged();
            }
        }

        public Step CurrentTestRequestStep
        {
            get { return currentTestRequestStep; }
            set
            {
                currentTestRequestStep = value;
                OnPropertyChanged();
            }
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class ObjectNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !Equals(value, null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
