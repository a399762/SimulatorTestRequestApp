using ICSharpCode.SharpZipLib.Zip;
using Ookii.Dialogs.Wpf;
using SimTestRequestBridge.Helpers;
using SimTestRequestBridge.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

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

        private void RRClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearTireSelect(TireLocationsCodes.RR);
        }
        private void RFClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearTireSelect(TireLocationsCodes.RF);
        }
        private void LRClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearTireSelect(TireLocationsCodes.LR);
        }
        private void LFClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearTireSelect(TireLocationsCodes.LF);
        }
        private void AllClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearTireSelect(TireLocationsCodes.All);
        }

        private void clearTireSelect(TireLocationsCodes code)
        {
            viewModel.ClearStepTire(code);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                viewModel.ClearCurrentTestRequestStagingFolder();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            viewModel.ClearCurrentTestRequestMasterCar();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tryStageCDB();
        }

        private void tryStageCDB()
        {
            VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog();
            bool? result = vistaFolderBrowserDialog.ShowDialog();

            if (result == true)
            {
                //if the folder does not end with .cdb, tell them to try again,... 
                if (!vistaFolderBrowserDialog.SelectedPath.ToLower().EndsWith(".cdb"))
                {
                    MessageBox.Show("Folder must end with '.cdb' i.e. RaceCar.cdb");
                    return;
                }

                bool stageResult = viewModel.StageVehicleCDB(vistaFolderBrowserDialog.SelectedPath);

                if (!stageResult)
                {
                    //elaborate...
                    MessageBox.Show("Error Staging CDB Folder/Files");
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //clear cdb file from db



        }

     
    }
}
