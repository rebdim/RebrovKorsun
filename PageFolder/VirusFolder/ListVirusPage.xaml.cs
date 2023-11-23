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
using RebrovKorsun.PageFolder;
using RebrovKorsun.WindowFolder;

namespace RebrovKorsun.PageFolder.VirusFolder
{
    /// <summary>
    /// Логика взаимодействия для ListVirusPage.xaml
    /// </summary>
    public partial class ListVirusPage : Page
    {
        public ListVirusPage()
        {
            InitializeComponent();
            ListVirusDg.ItemsSource = DBEntities.GetContext().Disease.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListVirusDg.ItemsSource = DBEntities.GetContext().Disease.Where(
                    d => d.DeseaseName.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void DeleteVirusMI_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem();
        }

        private void DeleteItem()
        {
            bool resultMB = MBClass.QuestionMB("Вы действительно хотите " +
                "удалить болезнь?");
            if (resultMB)
            {
                if (ListVirusDg.SelectedItem == null)
                {
                    MBClass.ErrorMB("Вы не выбрали строку");
                }
                else
                {
                    try
                    {
                        Disease disease = ListVirusDg.SelectedItem as Disease;
                        VariableClass.IdDisease = disease.IdDesease;
                        {
                            DBEntities.GetContext().Disease.Remove(disease);
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

        private void EditVirusMI_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
