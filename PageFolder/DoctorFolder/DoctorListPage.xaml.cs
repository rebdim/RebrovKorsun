using RebrovKorsun.Datafolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RebrovKorsun.ClassFolder;
using RebrovKorsun.PageFolder;
using RebrovKorsun.WindowFolder;
using RebrovKorsun.Properties;

namespace RebrovKorsun.PageFolder.DoctorFolder
{
    /// <summary>
    /// Логика взаимодействия для DoctorListPage.xaml
    /// </summary>
    public partial class DoctorListPage : Page
    {
        public DoctorListPage()
        {
            InitializeComponent();
            ListDoctorLb.ItemsSource = DBEntities.GetContext().Doctor.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListDoctorLb.ItemsSource = DBEntities.GetContext().Doctor.Where(
                    d => d.LastNameDoctor.StartsWith(SearchTb.Text) ||
                    d.FirstNameDoctor.StartsWith(SearchTb.Text) ||
                    d.MiddleNameDoctor.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void EditDoctor_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = ListDoctorLb.SelectedItem as Doctor;
            VariableClass.IdDoctor = doctor.IdDoctor;
            NavigationService.Navigate(new EditDoctorPage(ListDoctorLb.SelectedItem as Doctor));
        }

        private void DeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem();
        }

        private void DeleteItem()
        {
            bool resultMB = MBClass.QuestionMB("Вы действительно хотите " +
                "удалить доктора?");
            if (resultMB)
            {
                if (ListDoctorLb.SelectedItem == null)
                {
                    MBClass.ErrorMB("Вы не выбрали строку");
                }
                else
                {
                    try
                    {
                        Doctor doctor = ListDoctorLb.SelectedItem as Doctor;
                        VariableClass.IdDoctor = doctor.IdDoctor;
                        {
                            DBEntities.GetContext().Doctor.Remove(doctor);
                            DBEntities.GetContext().SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        MBClass.ErrorMB(ex);
                    }
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
