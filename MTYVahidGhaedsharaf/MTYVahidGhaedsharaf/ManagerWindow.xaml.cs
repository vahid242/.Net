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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public List<Manager> players;
        public ManagerWindow()
        {
            InitializeComponent();
            players = new List<Manager>()
            {
                new Manager(0, "James Karager", 75, 32.3, "Leader"),
                new Manager(1, "Ebrahamovich", 100, 9.7, "Motivator"),
                new Manager(2, "Mark Korone", 100, 12.8, "Decisiveness"),
                new Manager(3, "Louis Vanhal", 75, 18.3, "Leader, Visionary"),
                new Manager(4, "David Lorance", 75, 25.0, "Motivator")
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }
        private void RefreshList()
        {
            var playerNames = from ply in players
                              select ply.ToString();
            lstPlayer.ItemsSource = playerNames;
        }

        private void AddItem()
        {
            Manager ply = new Manager(players.Count, txtName.Text, int.Parse(txtMatch.Text),
                double.Parse(txtWon.Text), txtLost.Text);
            players.Add(ply);
            RefreshList();
        }

        private void UpdateItem()
        {
            int index = lstPlayer.SelectedIndex;

            Manager ply = players[index];
            ply.Name = txtName.Text;
            ply.PlayersRecruited = int.Parse(txtMatch.Text);
            ply.AvailableBudget = double.Parse(txtWon.Text);
            ply.Strength = txtLost.Text;
            RefreshList();
        }

        private void DeleteItem()
        {
            int index = lstPlayer.SelectedIndex;
            players.RemoveAt(index);
            for (int i = 0; i < players.Count; i++)
            {
                players[i].ID = i;
            }
            RefreshList();
        }

        private void lstPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstPlayer.SelectedIndex;
            var selectPly = (from ply in players
                             where ply.ID == index
                             select ply).FirstOrDefault();
            if (selectPly != null)
            {
                txtName.Text = selectPly.Name;
                txtMatch.Text = selectPly.PlayersRecruited.ToString();
                txtWon.Text = selectPly.AvailableBudget.ToString();
                txtLost.Text = selectPly.Strength;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                AddItem();
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                UpdateItem();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "")
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
                txtWon.Text == "" || txtLost.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                AddItem();
        }

        private void mnuUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                UpdateItem();
        }

        private void mnuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtMatch.Text == "" ||
                txtWon.Text == "" || txtLost.Text == "")
            {
                MessageBox.Show("There are empty text boxes or nobady is selected!");
            }
            else
                DeleteItem();
        }
    }
}
