using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using unit13_3;

namespace KarliCards.Gui
{
    public class GameViewModel : INotifyPropertyChanged
    {
        //事件，属性改变
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        //当前玩家
        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }
        //玩家列表
        private List<Player> players;
        public List<Player> Players
        {
            get { return players; }
            set
            {
                players = value;
                OnPropertyChanged(nameof(Players));
            }
        }
        //当前玩家手牌
        private Card availableCard;
        public Card CurrentAvailableCard
        {
            get { return availableCard; }
            set
            {
                availableCard = value;
                OnPropertyChanged(nameof(CurrentAvailableCard));
            }
        }
        //游戏牌堆
        private Deck deck;
        public Deck GameDeck
        {
            get { return deck; }
            set
            {
                deck = value;
                OnPropertyChanged(nameof(GameDeck));
            }
        }
        //游戏状态
        private bool gameStarted;
        public bool GameStarted
        {
            get { return gameStarted; }
            set
            {
                gameStarted = value;
                OnPropertyChanged(nameof(GameStarted));
            }
        }
        private GameOptions gameOptions;
        //关联菜单中的开始游戏选项
        public static RoutedCommand StartGameCommand = new RoutedCommand("Start New Game", typeof(GameViewModel),
            new InputGestureCollection(new List<InputGesture> { new KeyGesture(Key.N, ModifierKeys.Control) }));
        //关联菜单中的关于对话框
        public static RoutedCommand ShowAboutCommand = new RoutedCommand("Show About Dialog", typeof(GameViewModel));
        public GameViewModel()
        {
            //创建玩家列表
            Players = new List<Player>();
            //根据游戏选项创建游戏
            gameOptions = GameOptions.Create();
        }
        //开始游戏
        public void StartNewGame()
        {
            if (gameOptions.SelectdPlayers.Count < 1 || (gameOptions.SelectdPlayers.Count == 1 && !gameOptions.PlayAgainstComputer))
                return;
            //创建新游戏牌堆
            CreateGameDeck();
            //创建玩家
            CreatePlayers();
            //初始化游戏
            InitalizeGame();
            //游戏状态为true
            GameStarted = true;
        }
        private void InitalizeGame()
        {
            //改变玩家0状态为活动状态
            AssignCurrentPlayer(0);
            //初始化玩家手牌
            CurrentAvailableCard = GameDeck.Draw();
        }

        private void AssignCurrentPlayer(int index)
        {
            CurrentPlayer = Players[index];
            if (!Players.Any(x => x.State == PlayerState.Winner))
                Players.ForEach(x => x.State = (x == Players[index] ? PlayerState.Active : PlayerState.Inactive));
        }

        private void InitalizePlayer(Player player)
        {
            //添加玩家手牌
            player.DrawNewHand(GameDeck);
            //事件，出牌后改变玩家为非活动状态，并且若牌堆为空，则洗牌
            player.OnCardDiscarded += player_OnCardDiscarded;
            //事件，判断玩家是否获胜
            player.OnPlayerHasWon += player_OnPlayerHasWon;
            //添加玩家
            Players.Add(player);
        }

        void player_OnPlayerHasWon(object sender, PlayerEventArgs e)
        {
            Players.ForEach(x => x.State = (x == e.Player ? PlayerState.Winner : PlayerState.Loser));
        }

        void player_OnCardDiscarded(object sender, CardEventArgs e)
        {
            CurrentAvailableCard = e.Card;
            var nextIndex = CurrentPlayer.Index + 1 >= gameOptions.NumberOfPlayers ? 0 : CurrentPlayer.Index + 1;
            //牌堆为空，则重新洗牌
            if (GameDeck.CardsInDeck == 0)
            {
                var cardsInPlay = new List<Card>();
                foreach (var player in Players)
                    cardsInPlay.AddRange(player.GetCards());
                cardsInPlay.Add(CurrentAvailableCard);
                GameDeck.ReshuffleDiscarded(cardsInPlay);
            }
            //改变玩家状态为活动状态
            AssignCurrentPlayer(nextIndex);
        }

        private void CreatePlayers()
        {
            Players.Clear();
            //创建游戏玩家
            for (var i = 0; i < gameOptions.NumberOfPlayers; i++)
            {
                //判断玩家是否为电脑
                if (i < gameOptions.SelectdPlayers.Count)
                    InitalizePlayer(new Player
                    {
                        Index = i,
                        PlayerName = gameOptions.SelectdPlayers[i]
                    });
                else
                    InitalizePlayer(new ComputerPlayer
                    {
                        Index = i,
                        Skill = gameOptions.ComputerSkill
                    });
            }
        }

        private void CreateGameDeck()
        {
            //创建新的游戏牌堆
            GameDeck = new Deck();
            //牌堆乱序
            GameDeck.Shuffle();
        }
    }
}
