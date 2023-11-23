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
using RebrovKorsun.Datafolder;
using RebrovKorsun.WindowFolder;
using RebrovKorsun.PageFolder;

namespace RebrovKorsun.PageFolder.PatientFolder
{
    /// <summary>
    /// Логика взаимодействия для EditPatientPage.xaml
    /// </summary>
    public partial class EditPatientPage : Page
    {

        Datafolder.Patient patient = new Datafolder.Patient();
        public EditPatientPage(Patient patient)
        {
            InitializeComponent();
            DataContext = patient;
            EditRecordCB.ItemsSource = Datafolder.DBEntities.GetContext().RecordStatus.ToList();
        }

        private void EditPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                patient = DBEntities.GetContext()
              .Patient
                .FirstOrDefault(p => p.IdPatient == VariableClass.IdPatient);
                patient.PatientLastName = EditLastNameTB.Text;
                patient.PatientFirstName = EditFirstNameTB.Text;
                patient.PatientMiddleName = EditMiddleNameTB.Text;
                patient.PhoneNumber = EditPhoneNumberTB.Text;

                patient.IdRecord = Int32.Parse(EditRecordCB.SelectedValue.ToString());

                DBEntities.GetContext().SaveChanges();

                MBClass.InfoMB("Пациент отредактирован");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
