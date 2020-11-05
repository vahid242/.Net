using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MTYVahidGhaedsharaf
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Login login1 = new Login(1, "admin", "admin");

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, Login> myLogin = new Dictionary<string, Login>();
            myLogin.Add(login1.Username, login1);
            foreach (var item in myLogin)
            {
                if (txtUser.Text == item.Key && txtPass.Text == item.Value.Password)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                    MessageBox.Show("Username or Password is not correct", "Login Failed",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
