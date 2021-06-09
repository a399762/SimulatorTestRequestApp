using log4net;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TestRequestXMLParser;

namespace TestRequestUI
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly object _refreshLock = new object();
        private static readonly object _loadLock = new object();
        
        ThreadedBindingList<l2l1testreq> listOfTestRequests;


        public Form1()
        {
            InitializeComponent();
            
            listOfTestRequests = new ThreadedBindingList<l2l1testreq>();
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
                l2l1testreq selectedTestRequest = (l2l1testreq)((ListBox)sender).SelectedItem;

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


            //test 




        }


        private async void asyncLoadTestRequest(l2l1testreq selectedTestRequest)
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
                listOfTestRequests.Clear();

                String testRequestFolderPath = Properties.Settings.Default.TestRequestFolderPath;

                //with folder path, get list of files with .xml extensions
                var filteredFiles = Directory.EnumerateFiles(testRequestFolderPath).Where(file => file.ToLower().EndsWith("xml")).ToList();

                //using list of files, try importing each into the binding list
                foreach (var item in filteredFiles)
                {
                    try
                    {
                        // var request = TestRequestXMLParser.TestRequest.TestRequest.TestRequestParseFile(item);

                      //  string text = System.IO.File.ReadAllText(item);

                        //this works homie
                        XmlSerializer ser = new XmlSerializer(typeof(l2l1testreq));
                      //  Cars cars;
                        using (XmlReader reader = XmlReader.Create(item))
                        {
                            var test = (l2l1testreq)ser.Deserialize(reader);


                            var ddt = "";
                        }



                        // var f = Welcome1.FromJson(text);
                        string t = "";
                        // using System.Xml.Serialization;
                        //using (FileStream stream = new FileStream(item, FileMode.Open))
                        //{

                         //   var xsz = new XmlSerializer(typeof(L2l1testreq));
                        //    var request = (L2l1testreq)xsz.Deserialize(stream);


                        //  }
                      //  listOfTestRequests.Add(request.Tests.Test);

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

        private void LoadTestRequestSafe(l2l1testreq test)
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

                //when null, just clear forms
                if (test == null)
                {
                    testRequestNumberTextBox.Text = "";
                    testCodeTextBox.Text = "";




                }
                else 
                {
                    testRequestNumberTextBox.Text = test.tests.test.test_number;
                   // testCodeTextBox.Text = test.TestCode;
                }
            }
        }


        private void loadTestRequest(l2l1testreq test)
        {
            //allow only one running instance at a time.
            lock (_loadLock)
            {
                LoadTestRequestSafe(test);
            }
        }
    }
}
