using SimTestRequestBridge.ViewModels;
using System;
using System.Collections;
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

         //   var myListCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(Filters);
          //  myListCollectionView.CustomSort = new MyComparer();
          //  myListCollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

           // MyListCollectionView = myListCollectionView; // Which is binded by DG.ItemsSource

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewModel.OrderSelectedRunUp();
            var r = runDataGrid.Items;
        


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource source = (CollectionViewSource)(this.Resources["CurrentWorkingRunsCollectionView"]);
            ListCollectionView view = (ListCollectionView)source.View;
            view.CustomSort = new MyComparer();
        }
    }

    public class MyComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var a = x as SimBridge.Database.Run;
            var b = y as SimBridge.Database.Run;

            if (a == null || b == null)
                throw new ArgumentException("Not My CustomViewEntityViewModel");

            if (a.RunNumber > b.RunNumber)  // I added property SortOrder to my viewmodel
                return 1;
            if (a.RunNumber == b.RunNumber)
                return 0;

            return -1;
        }
    }
}
