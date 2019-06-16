using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace KarliCards.Gui
{
    [Serializable]
    public class GameOptions
    {
        private bool playAgainstComputer = true;
        public bool PlayAgainstComputer
        {
            get { return playAgainstComputer; }
            set
            {
                playAgainstComputer = value;
                OnPropertyChanged(nameof(PlayAgainstComputer));
            }
        }
        private int numberOfPlayers = 1;
        public int NumberOfPlayers
        {
            get { return numberOfPlayers; }
            set
            {
                numberOfPlayers = value;
                OnPropertyChanged(nameof(NumberOfPlayers));
            }
        }
        public int MinutesBeforeLoss { get; set; }
        private ComputerSkillLevel computerSkill = ComputerSkillLevel.Dumb;
        public ComputerSkillLevel ComputerSkill
        {
            get { return computerSkill; }
            set {
                computerSkill = value;
                OnPropertyChanged(nameof(ComputerSkill));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> playerNames = new ObservableCollection<string>();
        public List<string> SelectdPlayers { get; set; } = new List<string>();
        public ObservableCollection<string> PlayerNames
        {
            get
            {
                return playerNames;
            }
            set
            {
                playerNames = value;
                OnPropertyChanged("PlayerNames");
            }
        }
        public void AddPlayer(string playerName)
        {
            if (playerNames.Contains(playerName))
                return;
            playerNames.Add(playerName);
            OnPropertyChanged("PlayerNames");
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }

    [Serializable]
    public enum ComputerSkillLevel
    {
        Dumb,
        Good,
        Cheats
    }
}
