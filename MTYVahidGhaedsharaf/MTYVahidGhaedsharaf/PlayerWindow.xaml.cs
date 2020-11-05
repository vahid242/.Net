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
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public List<Player> players;
        public PlayerWindow()
        {
            InitializeComponent();
            players = new List<Player>()
            {
                new Player(0, "James Karager", 75, 32, 18, 25),
                new Player(1, "Mikel Owen", 100, 76, 34, 4),
                new Player(2, "Ashli Cole", 84, 48, 23, 12),
                new Player(3, "David Beckham", 125, 88, 26, 39),
                new Player(4, "Masoad Ozil", 80, 39, 25, 10)
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
            Player ply = new Player(players.Count, txtName.Text, int.Parse(txtMatch.Text),
                int.Parse(txtWon.Text), int.Parse(txtLost.Text), int.Parse(txtGoal.Text));
            players.Add(ply);
            RefreshList();
        }

        private void UpdateItem()
        {
            int index = lstPlayer.SelectedIndex;

            Player ply = players[index];
            ply.Name = txtName.Text;
            ply.MatchPlayed = int.Parse(txtMatch.Text);
            ply.Won = int.Parse(txtWon.Text);
            ply.Lost = int.Parse(txtLost.Text);
            ply.GoalsScored = int.Parse(txtGoal.Text);
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
            if(selectPly != null)
            {
                txtName.Text = selectPly.Name;
                txtMatch.Text = selectPly.MatchPlayed.ToString();
                txtWon.Text = selectPly.Won.ToString();
                txtLost.Text = selectPly.Lost.ToString();
                txtGoal.Text = selectPly.GoalsScored.ToString();
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
