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
using System.Linq;
namespace MTYVahidGhaedsharaf
{
    /// <summary>
    /// Interaction logic for CoachWindow.xaml
    /// </summary>
    public partial class CoachWindow : Window
    {
        public List<Coach> coaches;
        public CoachWindow()
        {
            InitializeComponent();
            coaches = new List<Coach>()
            {
                new Coach(0, "Alen Sherer", 5, 28, 75.89, 12),
                new Coach(1, "Ahmad Mamdov", 2, 26, 44.25, 5),
                new Coach(2, "Habib Koltore", 12, 28, 52.31, 16),
                new Coach(3, "Zidan", 1, 31, 67.25, 3),
                new Coach(4, "Todd Rechel", 8, 30, 41.08, 12)
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }
        private void RefreshList()
        {
            var playerNames = from ply in coaches
                              select ply.ToString();
            lstPlayer.ItemsSource = playerNames;
        }

        private void AddItem()
        {
            Coach ply = new Coach(coaches.Count, txtName.Text, int.Parse(txtMatch.Text),
                int.Parse(txtWon.Text), double.Parse(txtLost.Text), int.Parse(txtGoal.Text));
            coaches.Add(ply);
            RefreshList();
        }

        private void UpdateItem()
        {
            int index = lstPlayer.SelectedIndex;

            Coach ply = coaches[index];
            ply.Name = txtName.Text;
            ply.NumberOfTeamsCoached = int.Parse(txtMatch.Text);
            ply.PlayersTrained = int.Parse(txtWon.Text);
            ply.WinPercentage = double.Parse(txtLost.Text);
            ply.YearsOfExperience = int.Parse(txtGoal.Text);
            RefreshList();
        }

        private void DeleteItem()
        {
            int index = lstPlayer.SelectedIndex;
            coaches.RemoveAt(index);
            for (int i = 0; i < coaches.Count; i++)
            {
                coaches[i].ID = i;
            }
            RefreshList();
        }

        private void lstPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstPlayer.SelectedIndex;
            var selectPly = (from ply in coaches
                             where ply.ID == index
                             select ply).FirstOrDefault();
            if (selectPly != null)
            {
                txtName.Text = selectPly.Name;
                txtMatch.Text = selectPly.NumberOfTeamsCoached.ToString();
                txtWon.Text = selectPly.PlayersTrained.ToString();
                txtLost.Text = selectPly.WinPercentage.ToString();
                txtGoal.Text = selectPly.YearsOfExperience.ToString();
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "" || txtGoal.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                AddItem();
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "" || txtGoal.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                UpdateItem();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "" || txtGoal.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                DeleteItem();
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

        private void mnuInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "" || txtGoal.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                AddItem();
        }

        private void mnuUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "" || txtGoal.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                UpdateItem();
        }

        private void mnuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "" || txtGoal.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                DeleteItem();
        }
    }
}
