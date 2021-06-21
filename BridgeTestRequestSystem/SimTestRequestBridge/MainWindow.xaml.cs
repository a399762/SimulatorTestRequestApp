using SimTestRequestBridge.Helpers;
using SimTestRequestBridge.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

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
            //open staging folder? //also make this bound in vm?
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
        private void openDialogTireSelect(TireLocationsCodes tireLocation)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "TIR (*.tir,*.cdt31)|*.tir;*.cdt31|All files (*.*)|*.*";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                var filenames = new List<String>(dlg.FileNames);

                //now take file and pass to VM, to stage it. 
                bool stageResult = viewModel.StageTireFilesForCurrentStep(filenames, tireLocation);

                if (!stageResult)
                {
                    //elaborate...
                    MessageBox.Show("Error Staging Send File");
                }
            }
        }

        private void LFBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            openDialogTireSelect(TireLocationsCodes.LF);
        }

        private void RFBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            openDialogTireSelect(TireLocationsCodes.RF);
        }

        private void LRBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            openDialogTireSelect(TireLocationsCodes.LR);
        }

        private void RRBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            openDialogTireSelect(TireLocationsCodes.RR);
        }

        private void AllBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            openDialogTireSelect(TireLocationsCodes.All);
        }
    }
}
