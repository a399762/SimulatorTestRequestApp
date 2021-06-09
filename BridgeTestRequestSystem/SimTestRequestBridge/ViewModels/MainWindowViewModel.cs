using SimBridge.Database;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace SimTestRequestBridge.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<TestRequest> testRequests = new ObservableCollection<TestRequest>();
      
        private TestRequest currentTestRequest;
        private ObservableCollection<Run> currentTestRequestRuns = new ObservableCollection<Run>();
        private Run currentTestRequestRun;
        
        public MainWindowViewModel()
        {
            //load test requests
            LoadTestRequestsAsync();
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

        public Task LoadTestRequestsAsync()
        {
            return Task.Run(() => LoadTestRequests());
        }

        //buttons
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

        public ObservableCollection<TestRequest> TestRequests
        {
            get { return testRequests; }
            set
            {
                testRequests = value;
                OnPropertyChanged();
            }
        }

        public TestRequest CurrentTestRequest
        {
            get { return currentTestRequest; }
            set
            {
                currentTestRequest = value;


                try
                {
                    if (currentTestRequest != null)
                        //load here the runs for the test request
                        using (SimBridgeDataContext context = new SimBridgeDataContext())
                        {
                            CurrentTestRequestRuns = new ObservableCollection<Run>(DBHelper.GetTestRequestRuns(currentTestRequest.TestRequestID, context));
                        }
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
