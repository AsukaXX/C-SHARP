using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using unit13_3;

namespace KarliCards.Gui
{
    /// <summary>
    /// CardsInHandControl.xaml 的交互逻辑
    /// </summary>
    public partial class CardsInHandControl : UserControl
    {
        public CardsInHandControl()
        {
            InitializeComponent();
        }


        public Player Owner
        {
            get { return (Player)GetValue(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }

        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Player), typeof(CardsInHandControl), new PropertyMetadata(null, new PropertyChangedCallback(OnOwnerChanged)));

        public GameViewModel Game
        {
            get { return (GameViewModel)GetValue(GameProperty); }
            set { SetValue(GameProperty, value); }
        }

        public static readonly DependencyProperty GameProperty =
            DependencyProperty.Register("Game", typeof(GameViewModel), typeof(CardsInHandControl), new PropertyMetadata(null));

        public PlayerState Playerstate
        {
            get { return (PlayerState)GetValue(PlayerstateProperty); }
            set { SetValue(PlayerstateProperty, value); }
        }

        public static readonly DependencyProperty PlayerstateProperty =
            DependencyProperty.Register("Playerstate", typeof(PlayerState), typeof(CardsInHandControl), new PropertyMetadata(PlayerState.Inactive));
        public Orientation PlayerOrientation
        {
            get { return (Orientation)GetValue(PlayerOrientationProperty); }
            set { SetValue(PlayerOrientationProperty, value); }
        }

        public static readonly DependencyProperty PlayerOrientationProperty =
            DependencyProperty.Register("PlayerOrientation", typeof(Orientation), typeof(CardsInHandControl), new PropertyMetadata(Orientation.Horizontal));
        private static void OnOwnerChanged(DependencyObject source,DependencyPropertyChangedEventArgs e)
        {
            var control = source as CardsInHandControl;
            control.RedrawCards();
        }
        private static void OnPlayerStateChanged(DependencyObject source,DependencyPropertyChangedEventArgs e)
        {
            var control = source as CardsInHandControl;
            var computerPlayer = control.Owner as ComputerPlayer;
            if (computerPlayer != null)
            {
                if (computerPlayer.State == PlayerState.MustDiscard)
                {
                    Thread delayeWorker = new Thread(control.DelayDiscard);
                    delayeWorker.Start(new Payload { Deck = control.Game.GameDeck, AvailableCard = control.Game.CurrentAvailableCard, Player = computerPlayer });
                }
                else if (computerPlayer.State == PlayerState.Active)
                {
                    Thread delayedWorker = new Thread(control.DelayDraw);
                    delayedWorker.Start(new Payload { Deck = control.Game.GameDeck, AvailableCard = control.Game.CurrentAvailableCard, Player = computerPlayer });
                }
            }
            control.RedrawCards();
        }

        private void DelayDiscard(object payload)
        {
            Thread.Sleep(1250);
            var data = payload as Payload;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Deck>(data.Player.PerformDiscard), data.Deck);
        }

        private void DelayDraw(object payload)
        {
            Thread.Sleep(1250);
            var data = payload as Payload;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Deck>(data.Player.PerformDiscard), data.Deck);
        }

        private static void OnPlayerOrientationChanged(DependencyObject source,DependencyPropertyChangedEventArgs e)
        {
            var control = source as CardsInHandControl;
            control.RedrawCards();
        }
        private void RedrawCards()
        {
            CardSurface.Children.Clear();
            if (Owner == null)
            {
                PlayerNameLabel.Content = string.Empty;
                return;
            }
            DrawPlayerName();
            DrawCards();
        }

        private void DrawCards()
        {
            bool isFaceup = (Owner.State != PlayerState.Inactive);
            if (Owner is ComputerPlayer)
                isFaceup = (Owner.State == PlayerState.Loser || Owner.State == PlayerState.Winner);
            var cards = Owner.GetCards();
            if (cards == null || cards.Count == 0)
                return;
            for(var i = 0; i < cards.Count; i++)
            {
                var cardControl = new CardControl(cards[i]);
                if (PlayerOrientation == Orientation.Horizontal)
                    cardControl.Margin = new Thickness(i * 35, 35, 0, 0);
                else
                    cardControl.Margin = new Thickness(5, 35 + i * 30, 0, 0);
                cardControl.MouseDoubleClick += cardControl_MouseDoubleClick;
                cardControl.IsFaceUp = isFaceup;
                CardSurface.Children.Add(cardControl);
            }
        }

        private void cardControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedCard = sender as CardControl;
            if (Owner == null)
                return;
            if (Owner.State == PlayerState.MustDiscard)
                Owner.DiscardCard(selectedCard.Card);
            RedrawCards();
        }

        private void DrawPlayerName()
        {
            if (Owner.State == PlayerState.Winner || Owner.State == PlayerState.Loser)
                PlayerNameLabel.Content = Owner.PlayerName + (Owner.State == PlayerState.Winner ? "is the WINNER" : "has LOST");
            else
                PlayerNameLabel.Content = Owner.PlayerName;
            var isActuvePlayer = (Owner.State == PlayerState.Active || Owner.State == PlayerState.MustDiscard);
            PlayerNameLabel.FontSize = isActuvePlayer ? 18 : 24;
            PlayerNameLabel.Foreground = isActuvePlayer ? new SolidColorBrush(Colors.Gold) : new SolidColorBrush(Colors.White);
        }

        private class Payload
        {
            public Deck Deck { get; set; }
            public Card AvailableCard { get; set; }
            public ComputerPlayer Player { get; set; }
        }

    }
}
