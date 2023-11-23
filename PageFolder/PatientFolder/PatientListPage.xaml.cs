using RebrovKorsun.ClassFolder;
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
using RebrovKorsun.PageFolder;
using RebrovKorsun.WindowFolder;
using RebrovKorsun.Properties;
using RebrovKorsun.PageFolder.DoctorFolder;

namespace RebrovKorsun.PageFolder.PatientFolder
{
    /// <summary>
    /// Логика взаимодействия для PatientListPage.xaml
    /// </summary>
    public partial class PatientListPage : Page
    {
        public PatientListPage()
        {
            InitializeComponent();
            ListPAtientLb.ItemsSource = DBEntities.GetContext().Patient.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListPAtientLb.ItemsSource = DBEntities.GetContext().Patient.Where(
                    p => p.PatientLastName.StartsWith(SearchTb.Text) ||
                    p.PatientFirstName.StartsWith(SearchTb.Text) ||
                    p.PatientMiddleName.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = ListPAtientLb.SelectedItem as Patient;
            VariableClass.IdPatient = patient.IdPatient;
            NavigationService.Navigate(new EditPatientPage(ListPAtientLb.SelectedItem as Patient));
        }

        private void DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem();
        }

        private void DeleteItem()
        {
            bool resultMB = MBClass.QuestionMB("Вы действительно хотите " +
                "удалить пациента?");
            if (resultMB)
            {
                if (ListPAtientLb.SelectedItem == null)
                {
                    MBClass.ErrorMB("Вы не выбрали строку");
                }
                else
                {
                    try
                    {
                        Patient patient = ListPAtientLb.SelectedItem as Patient;
                        VariableClass.IdPatient = patient.IdPatient;
                        {
                            DBEntities.GetContext().Patient.Remove(patient);
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
    }
}
