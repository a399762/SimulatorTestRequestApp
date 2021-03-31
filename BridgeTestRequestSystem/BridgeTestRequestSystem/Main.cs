using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestRequestParser;

namespace BridgeTestRequestSystem
{
    public partial class Main : Form
    {
     

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Open selected file, attempt to parse

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "XML files (*.xml)|*.xml;";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFileName = openFileDialog1.FileName;


                    var  request = TestRequest.TestRequestParse(selectedFileName);
                    String t = "";

                }
            }
            catch (Exception ee)
            {
                String t = "";
            }




        }
    }
}
