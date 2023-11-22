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
using RebrovKorsun.Datafolder;

namespace RebrovKorsun.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    /// 
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ExitBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Вы не ввели логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MBClass.ErrorMB("Вы не ввели пароль");
                PasswordPB.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.Login == LoginTB.Text);

                    if (user == null)
                    {
                        MBClass.ErrorMB("Введён не верный логин");
                        LoginTB.Focus();
                        return;
                    }
                    if (user.Password != PasswordPB.Password)
                    {
                        MBClass.ErrorMB("Введён не верный логин");
                        PasswordPB.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 2:
                                new MainWindow().ShowDialog();
                                this.Close();
                                break;
                        }
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
