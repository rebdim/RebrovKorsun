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

namespace RebrovKorsun.PageFolder.DoctorFolder
{
    /// <summary>
    /// Логика взаимодействия для EditDoctorPage.xaml
    /// </summary>
    public partial class EditDoctorPage : Page
    {

        Datafolder.Doctor doctor = new Datafolder.Doctor();
        public EditDoctorPage(Doctor doctor)
        {
            InitializeComponent();
            DataContext = doctor;
            EditJobTitleCB.ItemsSource = Datafolder.DBEntities.GetContext().JobTitle.ToList();
            EditDoctorCategoryCB.ItemsSource = Datafolder.DBEntities.GetContext().DoctorCategory.ToList();
            EditCabNumberCB.ItemsSource = Datafolder.DBEntities.GetContext().Cab.ToList();
            EditDoctorStatusCB.ItemsSource = Datafolder.DBEntities.GetContext().DoctorStatus.ToList();
        }

        private void EditDoctorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doctor = DBEntities.GetContext()
              .Doctor
                .FirstOrDefault(d => d.IdDoctor == VariableClass.IdDoctor);
                doctor.LastNameDoctor = EditLastNameTB.Text;
                doctor.FirstNameDoctor = EditFirstNameTB.Text;
                doctor.MiddleNameDoctor = EditMiddleNameTB.Text;
                doctor.DateOfBirth = (DateTime)EditDateOfBirthDP.SelectedDate;
                doctor.Phone = EditPhoneNumberTB.Text;

                doctor.IdJobTitle = Int32.Parse(EditJobTitleCB.SelectedValue.ToString());
                doctor.IdDoctorCategory = Int32.Parse(EditDoctorCategoryCB.SelectedValue.ToString());
                doctor.IdCab = Int32.Parse(EditCabNumberCB.SelectedValue.ToString());
                doctor.IdDoctorStatus = Int32.Parse(EditDoctorStatusCB.SelectedValue.ToString());

                DBEntities.GetContext().SaveChanges();

                MBClass.InfoMB("Доктор отредактирован");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
