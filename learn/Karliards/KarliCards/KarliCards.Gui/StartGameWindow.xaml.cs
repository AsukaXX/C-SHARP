using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KarliCards.Gui
{
    /// <summary>
    /// StartGameWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartGameWindow : Window
    {
        private GameOptions gameOptions;
        public StartGameWindow()
        {
            /*if (gameOptions == null)
            {
                if (File.Exists("GameOptions.xml"))
                {
                    using (var stream = File.OpenRead("GameOptions.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(GameOptions));
                        gameOptions = serializer.Deserialize(stream) as GameOptions;
                    }
                }
                else
                    gameOptions = new GameOptions();
            }
            DataContext = gameOptions;*/
            InitializeComponent();
            //ChangeListBoxOptions();
            DataContextChanged += StartGame_DataContextChanged;
        }

        private void ChangeListBoxOptions()
        {
            if (gameOptions.PlayAgainstComputer)
                playerNamesListBox.SelectionMode = SelectionMode.Single;
            else
                playerNamesListBox.SelectionMode = SelectionMode.Extended;
        }


        private void playerNamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gameOptions.PlayAgainstComputer)
                okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count == 1);
            else
                okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count == gameOptions.NumberOfPlayers);
        }

        private void addNewPlyerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newPlayerTextBox.Text))
                gameOptions.AddPlayer(newPlayerTextBox.Text);
            newPlayerTextBox.Text = string.Empty;
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            /*foreach (string item in playerNamesListBox.SelectedItems)
            {
                gameOptions.SelectdPlayers.Add(item);
            }
            using (var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, gameOptions);
            }
            Close();*/
            var gameOptions = DataContext as GameOptions;
            gameOptions.SelectdPlayers = new List<string>();
            foreach (string item in playerNamesListBox.SelectedItems)
            {
                gameOptions.SelectdPlayers.Add(item);
            }
            this.DialogResult = true;
            this.Close();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            gameOptions = null;
            Close();
        }
        void StartGame_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            gameOptions = DataContext as GameOptions;
            ChangeListBoxOptions();
        }
    }
}
