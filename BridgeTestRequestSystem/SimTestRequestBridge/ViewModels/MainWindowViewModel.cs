using Microsoft.EntityFrameworkCore;
using SimBridge.Database;
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

namespace SimTestRequestBridge.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //place in settings
        private string stagingPath = @"C:\Staging\";

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<TestRequest> testRequests = new ObservableCollection<TestRequest>();
        private ObservableCollection<TestRequest> completedTestRequests = new ObservableCollection<TestRequest>();
        private ObservableCollection<Run> currentTestRequestRuns = new ObservableCollection<Run>();
        private ObservableCollection<TireType> tireTypes = new ObservableCollection<TireType>();

        //one to keep track of what is selected, the other to actively modify
        private TestRequest currentSelectedTestRequest;
        private TestRequest currentWorkingTestRequest;

        private Run currentTestRequestRun;
        
        public MainWindowViewModel()
        {
            LoadTireTypesAsync();
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

        private void LoadTireTypes()
        {
            using (SimBridgeDataContext context = new SimBridgeDataContext())
            {
                var tiretypes = context.TireTypes.ToList();

                if (tiretypes != null)
                    TireTypes = new ObservableCollection<TireType>(tiretypes);
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
                using (SimBridgeDataContext context = new SimBridgeDataContext())
                {
                    context.Entry(CurrentWorkingTestRequest).State = EntityState.Modified;
                   
                    if(CurrentTestRequestRun != null)
                        context.Entry(CurrentTestRequestRun).State = EntityState.Modified;


                    if(CurrentWorkingTestRequest != null && CurrentWorkingTestRequest.Runs != null)
                        foreach (var item in CurrentWorkingTestRequest.Runs.Where(i=>i.RunID == 0))
                        {
                           // context.Attach(item);
                            context.Entry(item).State = EntityState.Added;
                        }

                  

                    context.SaveChanges();
                }

                //LoadTestRequest(CurrentWorkingTestRequest.TestRequestID);

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
                using (SimBridgeDataContext context = new SimBridgeDataContext())
                {
                    CurrentWorkingTestRequest = DBHelper.GetTestRequest(context, testRequestID);
                    CurrentTestRequestRuns = new ObservableCollection<Run>(DBHelper.GetTestRequestRuns(testRequestID, context));
                }
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


        private void AddNewRunToCurrentTestRequest()
        {

            using (SimBridgeDataContext context = new SimBridgeDataContext())
            {

                Tire lf = new Tire();
                lf.Construction = "40930dpo";
                lf.Pressure = 30;
                lf.TirePath = "Path/to/tir/file";
                Tire rf = new Tire();
                rf.Construction = "40930dpo";
                rf.Pressure = 30;
                rf.TirePath = "Path/to/tir/file";
                Tire rr = new Tire();
                rr.Construction = "40930dpo";
                rr.Pressure = 30;
                rr.TirePath = "Path/to/tir/file";
                Tire lr = new Tire();
                lr.Construction = "40930dpo";
                lr.Pressure = 30;
                lr.TirePath = "Path/to/tir/file";

                Run run = new Run();
                run.GeneratedRunSendFilePath = "testpath";
                run.LFTire = lf;
                run.RFTire = rf;
                run.RRTire = rr;
                run.LRTire = lr;
                run.TireTypeID = 1;
                run.Location = "VIR";
                run.Maneuver = "Drive fast";



                currentTestRequestRuns.Add(run);
            }


            string t = "";

            //_context.Attach(modelPostedToController);

            //IEnumerable<EntityEntry> unchangedEntities = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Unchanged);

            //foreach (EntityEntry ee in unchangedEntities)
            //{
            //    ee.State = EntityState.Modified;
            //}

            //await _context.SaveChangesAsync();


        }
        //ICommand button callbacks

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

        public void testGenerateNewTestRequest()
        {
            //check if there is a car use first, else create then use
            using (SimBridgeDataContext context = new SimBridgeDataContext())
            {

                var cars = DBHelper.GetCars(context);

                Car car;
                if (cars != null && cars.Count == 0)
                {

                    car = new Car();
                    car.Description = "Test Car";
                    DBHelper.InsertCar(car, context);
                }
                else
                {
                    car = cars[0];
                }

                TestRequest testRequest = new TestRequest();
                testRequest.Car = car;
                testRequest.Description = "test";
                testRequest.RecievedTime = DateTime.Now;
                testRequest.TestRequestID = Guid.NewGuid().ToString();

                

                Tire lf = new Tire();
                lf.Construction = "40930dpo";
                lf.Pressure = 30;
                lf.TirePath = "Path/to/tir/file";
                Tire rf = new Tire();
                rf.Construction = "40930dpo";
                rf.Pressure = 30;
                rf.TirePath = "Path/to/tir/file";
                Tire rr = new Tire();
                rr.Construction = "40930dpo";
                rr.Pressure = 30;
                rr.TirePath = "Path/to/tir/file";
                Tire lr = new Tire();
                lr.Construction = "40930dpo";
                lr.Pressure = 30;
                lr.TirePath = "Path/to/tir/file";

                Run run = new Run();
                run.GeneratedRunSendFilePath = "testpath";
                run.LFTire = lf;
                run.RFTire = rf;
                run.RRTire = rr;
                run.LRTire = lr;
                run.TireTypeID = 1;
                run.Location = "VIR";
                run.Maneuver = "Drive fast";
                testRequest.Runs = new System.Collections.Generic.List<Run>();
                testRequest.Runs.Add(run);


                try
                {
                    DBHelper.InsertTestRequest(testRequest, context);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    string t = "";
                }

            }

            LoadTestRequestsAsync();
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
                        CurrentTestRequestRuns.Clear();

                }
                catch (Exception err)
                {

                    string t = "";
                }

                OnPropertyChanged();
            }
        }
        public ObservableCollection<Run> CurrentTestRequestRuns
        {
            get { return currentTestRequestRuns; }
            set
            {
                currentTestRequestRuns = value;
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
