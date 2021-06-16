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
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace SimTestRequestBridge.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //place in settings
        private string stagingPath = @"C:\Staging\";

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<TestRequest> testRequests = new ObservableCollection<TestRequest>();
        private ObservableCollection<TestRequest> completedTestRequests = new ObservableCollection<TestRequest>();
        private ObservableCollection<Run> currentWorkingTestRequestRuns = new ObservableCollection<Run>();

        private ObservableCollection<TireType> tireTypes;
        private ObservableCollection<Location> locations; 

        //one to keep track of what is selected, the other to actively modify
        private TestRequest currentSelectedTestRequest;
        private TestRequest currentWorkingTestRequest;
      
        private Run currentTestRequestRun;
        private SimBridgeDataContext currentWorkingContext;


        public MainWindowViewModel()
        {
            this.CurrentWorkingTestRequestRuns = new ObservableCollection<Run>();


     
            LoadTireTypesAsync();
            LoadLocationsAsync();
            LoadTestRequestsAsync();
        }

        public Task<bool> StageVehicleSendFileAsync(string filename)
        {
            return Task<bool>.Run(() => StageVehicleSendFile(filename));
        }

        public string GetCurrentStagingFolder()
        {
            if (CurrentWorkingTestRequest != null)
                return GetStagingFolderForTestRequest(CurrentWorkingTestRequest.TestRequestID);
            else
               return null;
        }

        public string GetStagingFolderForTestRequest(string testRequestID)
        {
            if (FileHelper.CreateStagingFolderIfNotExist(testRequestID, stagingPath))
                return stagingPath + testRequestID + @"\";
            return null;
        }

        private bool StageVehicleSendFile(string filename)
        {
            bool result = false;
            if (CurrentWorkingTestRequest != null)
            {
                if (!FileHelper.CreateStagingFolderIfNotExist(CurrentWorkingTestRequest.TestRequestID, stagingPath))
                    return false;

                if (!StageSendFile(CurrentWorkingTestRequest, filename))
                    return false;

                result = true;
            }

            return result;
   
        }

        /// <summary>
        /// check that all information is filled out in the run, i.e. All tires are entered into 
        /// </summary>
        /// <param name="currentTestRequestRun"></param>
        /// <returns></returns>
        internal bool ValidateTestRequestForRun(Run currentTestRequestRun)
        {
            //check to make sure each tire has a tire path
            if (currentTestRequestRun.LFTire.TirePath != null || currentTestRequestRun.LFTire.TirePath != null || currentTestRequestRun.LFTire.TirePath != null && currentTestRequestRun.LFTire.TirePath != null)
            {
                return true;
            }

            return false;
        }

        public bool ValidateTestRequestRun
        {
            get
            {
                if (currentTestRequestRun != null)
                    return ValidateTestRequestForRun(currentTestRequestRun);
                else
                    return false;
            }
        }

        private bool StageSendFile(TestRequest currentTestRequest, string filename)
        {
            //copy file to staging folder for test session
            string fileNameOnly = Path.GetFileName(filename);
            string newfileLocation = GetStagingFolderForTestRequest(currentTestRequest.TestRequestID) + @"\" + fileNameOnly;
            
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

        public Task LoadTireTypesAsync()
        {
            return Task.Run(() => LoadTireTypes());
        }

        public Task LoadLocationsAsync()
        {
            return Task.Run(() => LoadLocations());
        }

        private void LoadTireTypes()
        {
            using (SimBridgeDataContext context = new SimBridgeDataContext())
            {
                var tiretypes = context.TireTypes.ToList();

                if (tiretypes != null)
                    TireTypes = new ObservableCollection<TireType>(tiretypes);
            }
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
        private void LoadTestRequest(string testRequestID)
        {
            try
            {
                currentWorkingContext = new SimBridgeDataContext();
                CurrentWorkingTestRequest = DBHelper.GetTestRequest(currentWorkingContext, testRequestID);
                CurrentWorkingTestRequestRuns = new ObservableCollection<Run>(CurrentWorkingTestRequest.Runs);
            }
            catch (Exception err)
            {

                throw;
            }
        }
        private bool StageCurrentSession()
        {
            try
            {
                //send all files from test request stage folder to simulator over ftp
                //catch errors.....
                IEnumerable<string> files = Directory.EnumerateFiles(GetCurrentStagingFolder());

                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential("username", "password");

                    foreach (string file in files)
                    {
                        string remoteTestSessionPath = GetCurrentRemoteStagingFolderForTestRequest();
                        client.UploadFile("ftp://example.com/remote/folder/" + Path.GetFileName(file), file);
                    }
                }
            }
            catch (Exception err)
            {
                return false;
            }

            return true;
        }

        private string GetCurrentRemoteStagingFolderForTestRequest()
        {
            return GetRemoteStagingFolderForTestRequest(currentWorkingTestRequest.TestRequestID);
        }

        private string GetRemoteStagingFolderForTestRequest(string testRequestID)
        {
            string path = "/vigrade/vicrt/";
            return path + testRequestID;
        }

        private void GenerateSendFileForCurrentRun()
        {

            //grab current send file
            var originalSendFile = CurrentWorkingTestRequest.SendFilePath;
            String rawSendFileXML = File.ReadAllText(originalSendFile);
            XDocument doc = XDocument.Parse(rawSendFileXML);

            string testTire = "mdids://VW_Golf8_150cv_eTSI_copy2/tires.tbl/CDTire/MOD1_GY_EFG_PERF_20555R16_91V_HG9535_RTmodel_implicit_44MP_v3.tir";

            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.fl_tire_property_file, testTire, doc);
            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.fr_tire_property_file, testTire, doc);
            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.rl_tire_property_file, testTire, doc);
            SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.rr_tire_property_file, testTire, doc);

            //place it next to the original send file for now
            var path = Path.GetDirectoryName(originalSendFile);

            //where do we want to save...
            var runSendFilePath = path + @"\" + CurrentWorkingTestRequest.Car.Description + "_" + currentTestRequestRun.LocationID + "_" + currentTestRequestRun.LFTire.Construction + "_" + currentTestRequestRun.RFTire.Construction + "_" + currentTestRequestRun.LRTire.Construction + "_" + currentTestRequestRun.RRTire.Construction + ".xml";
            doc.Save(runSendFilePath);
        }

        private void AddNewRunToCurrentTestRequest()
        {
            if (currentWorkingTestRequest != null )
            {
                Tire lf = new Tire();
                lf.Construction = "40930dpo";
                lf.Pressure = 31;
                lf.TirePath = "Path/to/tir/file";
                Tire rf = new Tire();
                rf.Construction = "40930dpo";
                rf.Pressure = 31;
                rf.TirePath = "Path/to/tir/file";
                Tire rr = new Tire();
                rr.Construction = "20930dpo";
                rr.Pressure = 33;
                rr.TirePath = "Path/to/tir/file";
                Tire lr = new Tire();
                lr.Construction = "20930dpo";
                lr.Pressure = 33;
                lr.TirePath = "Path/to/tir/file";

                Run run = new Run();
                run.GeneratedRunSendFilePath = "testpath";
                run.LFTire = lf;
                run.RFTire = rf;
                run.RRTire = rr;
                run.LRTire = lr;
                run.TireModelType = currentWorkingContext.TireTypes.FirstOrDefault(i => i.TireTypeID == 1);
                run.RunLocation = currentWorkingContext.Locations.FirstOrDefault(i => i.LocationID == 1);
                run.Maneuver = "Slalom";

                //get next number to use based on existing - 1 based
                var newNumber = currentWorkingTestRequestRuns.Count() + 1;
                run.RunNumber = newNumber;

                CurrentWorkingTestRequest.Runs.Add(run);
                currentWorkingTestRequestRuns.Add(run);
            }
        }

        void MoveAndUpdateOrder(ICollection<Run> list, Run item, int positionToInsert)
        {
            if (positionToInsert >   0)
            {
                // Order elements
                var ordered_list = list.OrderBy(a => a.RunNumber).ToList();

                // Remove and insert at the proper position
                ordered_list.Remove(item);
                ordered_list.Insert(positionToInsert - 1, item);

                // Update the Order properties according to it's current index +1
                for (int i = 0; i < ordered_list.Count; i++)
                    ordered_list[i].RunNumber = i + 1;
            }
        }
        
  private ICommand _openStagingFolderCommand;
        public ICommand OpenStagingFolderCommand
        {
            get
            {
                return _openStagingFolderCommand ?? (_openStagingFolderCommand = new CommandHandler(() => DeleteSelectedRun(), () => ValidateTestRequestRun));
            }
        }

        private ICommand _deleteTestRequestRunCommand;
        public ICommand DeleteTestRequestRunCommand
        {
            get
            {
                return _deleteTestRequestRunCommand ?? (_deleteTestRequestRunCommand = new CommandHandler(() => DeleteSelectedRun(), () => ValidateTestRequestRun));
            }
        }

        private ICommand _deleteTestRequestCommand;
        public ICommand DeleteTestRequestCommand
        {
            get
            {
                return _deleteTestRequestCommand ?? (_deleteTestRequestCommand = new CommandHandler(() => DeleteSelectedTestRequest(), () => ValidateTestRequestRun));
            }
        }

        private void DeleteSelectedTestRequest()
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedRun()
        {
            var run = currentTestRequestRun;

            currentWorkingTestRequestRuns.Remove(run);
            currentWorkingContext.Remove(run);
            currentWorkingTestRequest.Runs.Remove(run);

            //re number each run 
            var ordered_list = currentWorkingTestRequest.Runs.OrderBy(a => a.RunNumber).ToList();
            for (int i = 0; i < ordered_list.Count; i++)
                ordered_list[i].RunNumber = i + 1;

        }

        private ICommand _orderRunUpCommand;
        public ICommand OrderRunUpCommand
        {
            get
            {
                return _orderRunUpCommand ?? (_orderRunUpCommand = new CommandHandler(() => OrderSelectedRunUp(), () => ValidateTestRequestRun));
            }
        }

        private ICommand _orderRunDownCommand;
        public ICommand OrderRunDownCommand
        {
            get
            {
                return _orderRunDownCommand ?? (_orderRunDownCommand = new CommandHandler(() => OrderSelectedRunDown(), () => ValidateTestRequestRun));
            }
        }

        public void OrderSelectedRunUp()
        {
            MoveAndUpdateOrder(currentWorkingTestRequest.Runs, currentTestRequestRun, currentTestRequestRun.RunNumber - 1);
        }   
        public void OrderSelectedRunDown()
        {
            MoveAndUpdateOrder(currentWorkingTestRequest.Runs, currentTestRequestRun, currentTestRequestRun.RunNumber + 1);
        }

        //ICommand button callbacks
        private ICommand _generateSendFile;
        public ICommand GenerateSendFile
        {
            get
            {
                return _generateSendFile ?? (_generateSendFile = new CommandHandler(() => GenerateSendFileForCurrentRun(), () => ValidateTestRequestRun));
            }
        }

        private ICommand _newRunCommand;
        public ICommand NewRunCommand
        {
            get
            {
                return _newRunCommand ?? (_newRunCommand = new CommandHandler(() => AddNewRunToCurrentTestRequest(), () => CanExecute));
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
            using (SimBridgeDataContext context = new SimBridgeDataContext())
            {
                var car = DBHelper.GetCars(context)[0];

                TestRequest testRequest = new TestRequest();
                testRequest.Car = car;
                testRequest.Description = "test";
                testRequest.RecievedTime = DateTime.Now;
                testRequest.TestRequestID = Guid.NewGuid().ToString();

                TestRequests.Add(testRequest);

                DBHelper.InsertTestRequest(testRequest, context);

                context.SaveChanges();
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


        public ObservableCollection<TireType> TireTypes
        {
            get { return tireTypes; }
            set
            {
                tireTypes = value;
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
        public ObservableCollection<Run> CurrentWorkingTestRequestRuns
        {
            get { return currentWorkingTestRequestRuns; }
            set
            {
                currentWorkingTestRequestRuns = value;
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

        public Run CurrentTestRequestRun
        {
            get { return currentTestRequestRun; }
            set
            {
                currentTestRequestRun = value;
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
