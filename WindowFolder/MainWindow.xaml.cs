using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using RebrovKorsun.ClassFolder;

namespace RebrovKorsun.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RollupBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CloseBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void TopperBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void ExitBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void MainFrame_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShopBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VehicleBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StorageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContractBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RollupBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.DoctorFolder.DoctorListPage());
        }

        private void TopperBorder_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void ExitBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            new AuthorizationWindow().Show();

            Close();
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.PatientFolder.PatientListPage());
        }

        private void Image_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.VirusFolder.ListVirusPage());
        }
    }
}
