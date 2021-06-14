using SimTestRequestBridge.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimTestRequestBridge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = this.DataContext as MainWindowViewModel;
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.XML)|*.xml";
         
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
               string filename = dlg.FileName;

                //now take file and pass to VM, to stage it. 
               bool stageResult = await viewModel.StageVehicleSendFileAsync(filename);

                if (!stageResult)
                {
                    //elaborate...
                    MessageBox.Show("Error Staging Send File");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //open staging folder?
            try
            {
                string stagingPath = viewModel.GetCurrentStagingFolder();

                if (stagingPath != null)
                {
                    Process.Start("explorer.exe", stagingPath);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
