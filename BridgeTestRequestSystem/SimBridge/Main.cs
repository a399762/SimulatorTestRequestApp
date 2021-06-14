using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml.XPath;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using SimBridge.Helpers;
using SimBridge.Database;

namespace SimBridge
{
    public partial class Main : Form
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly object _refreshLock = new object();
        private static readonly object _loadLock = new object();

        ThreadedBindingList<TestRequest> listOfTestRequests;

        public Main()
        {
            InitializeComponent();
            setup();
            refreshCars();

            //init items
            //asyncLoadTestRequests();
        }

        private void setup()
        {
            //list of requests
            listOfTestRequests = new ThreadedBindingList<TestRequest>();
            testRequestListBox.DisplayMember = "Test_number";
            testRequestListBox.ValueMember = "Test_number";
            testRequestListBox.DataSource = listOfTestRequests;
            testRequestListBox.SelectedIndexChanged += TestRequestListBox_SelectedIndexChanged;
        }

        private void TestRequestListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }


        //private async void asyncLoadTestRequest(l2l1testreq selectedTestRequest)
        //{
        //    await Task.Run(() => loadTestRequest(selectedTestRequest));
        //}



        /// <summary>
        /// Refresh the request list
        /// </summary>
        private void loadTestRequests()
        {
            var testRequests = DBHelper.GetTestRequests();

            foreach (var item in testRequests)
            {
                listOfTestRequests.Add(item);
            }

            SelectIndexSafe(-1);            
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

   

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //read text into stirng for later mod, and saving modded
                    String rawSendFileXML = File.ReadAllText(openFileDialog.FileName);


                    XDocument doc = XDocument.Parse(rawSendFileXML);

                    string testTire = "mdids://VW_Golf8_150cv_eTSI_copy2/tires.tbl/CDTire/MOD1_GY_EFG_PERF_20555R16_91V_HG9535_RTmodel_implicit_44MP_v3.tir";

                    SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.fl_tire_property_file, testTire, doc);
                    //SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.fr_tire_property_file, testTire, doc);
                    //SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.rl_tire_property_file, testTire, doc);
                    //SendFileHelper.SetTirePropertyFilePath(SendFileHelper.TirePositionProperties.rr_tire_property_file, testTire, doc);

                    //string newfile = Path.GetDirectoryName(openFileDialog.FileName) + @"\" + Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "_new.xml";

                    //doc.Save(newfile);
                }
                catch (Exception ef) 
                {

                    String t = "";
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TestRequest testRequest = new TestRequest();

            var car = (Car)listBox2.SelectedItem;
            testRequest.TestRequestID = textBox5.Text.Trim();
            testRequest.Car = car;
            testRequest.Description = "Test - Test request in order to flex the DB and file create capabilities.";

            DBHelper.InsertTestRequest(testRequest);
            refreshTestRequests();
        }

        private void refreshTestRequests()
        {
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //insert new car
            Car car = new Car();
            car.Description = carNameTextBox.Text.Trim();

            DBHelper.InsertCar(car);
            refreshCars();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //refresh car list
            refreshCars();
        }

        private void refreshCars()
        {
            var list = DBHelper.GetCars();
            listBox2.DataSource = list;
            listBox2.DisplayMember = "Description";
        }
    }
}

