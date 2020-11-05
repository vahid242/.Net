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

namespace MTYVahidGhaedsharaf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlayer_Click(object sender, RoutedEventArgs e)
        {
            PlayerWindow playerWindow = new PlayerWindow();
            playerWindow.Show();
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit program?", "Quit",
               MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }

        }

        private void btnCoach_Click(object sender, RoutedEventArgs e)
        {
            CoachWindow coachWindow = new CoachWindow();
            coachWindow.Show();
        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindoe = new ManagerWindow();
            managerWindoe.Show();
        }
    }
}
