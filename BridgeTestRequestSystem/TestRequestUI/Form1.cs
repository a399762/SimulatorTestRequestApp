using log4net;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestRequestXMLParser;

namespace TestRequestUI
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly object _refreshLock = new object();
        private static readonly object _loadLock = new object();
        
        ThreadedBindingList<Test> listOfTestRequests;


        public Form1()
        {
            InitializeComponent();
            
            listOfTestRequests = new ThreadedBindingList<Test>();
            testRequestListBox.DisplayMember = "Test_number";
            testRequestListBox.ValueMember = "Test_number";
            testRequestListBox.DataSource = listOfTestRequests;
         
            testRequestListBox.SelectedIndexChanged += TestRequestListBox_SelectedIndexChanged;

            //init items
            asyncLoadTestRequests();
        }

        private void TestRequestListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //load selected test request
                Test selectedTestRequest = (Test)((ListBox)sender).SelectedItem;

                asyncLoadTestRequest(selectedTestRequest);
            }
            catch (Exception err)
            {
                log.Info("Error selecting Test Request:" + err.Message);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //refresh list of test requests
            asyncLoadTestRequests(); 
        }


        private async void asyncLoadTestRequest(Test selectedTestRequest)
        {
            await Task.Run(() => loadTestRequest(selectedTestRequest));
        }


        private async void asyncLoadTestRequests()
        {
            await Task.Run(() => loadTestRequests());
        }

        /// <summary>
        /// Refresh the request list
        /// </summary>
        private void loadTestRequests()
        {
            //allow only one running instance at a time.
            lock (_refreshLock)
            {
                String testRequestFolderPath = Properties.Settings.Default.TestRequestFolderPath;

                //with folder path, get list of files with .xml extensions
                var filteredFiles = Directory.EnumerateFiles(testRequestFolderPath).Where(file => file.ToLower().EndsWith("xml")).ToList();

                //using list of files, try importing each into the binding list
                foreach (var item in filteredFiles)
                {
                    try
                    {
                        var request = TestRequest.TestRequestParse(item);
                        listOfTestRequests.Add(request.Tests.Test);
                    }
                    catch (Exception err)
                    {
                        log.Info("Error Opening File:" + Path.GetFileName(item) + err.Message );
                    }
                }

                SelectIndexSafe(-1);
            }
        }

        private void SelectIndexSafe(int index)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SelectIndexSafe(index);
                }));
            }
            else
            {
                testRequestListBox.SelectedIndex = index;
            }
        }

        private void LoadTestRequestSafe(Test test)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    LoadTestRequestSafe(test);
                }));
            }
            else
            {
               //load all items for UI consumption here


            }
        }


        private void loadTestRequest(Test test)
        {
            //allow only one running instance at a time.
            lock (_loadLock)
            {
                if(test != null)
                {
                    LoadTestRequestSafe(test);

                }
            }
        }
    }
}
