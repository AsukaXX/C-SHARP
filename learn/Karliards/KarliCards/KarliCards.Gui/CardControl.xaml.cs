using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KarliCards.Gui
{
    /// <summary>
    /// CardControl.xaml 的交互逻辑
    /// </summary>
    public partial class CardControl : UserControl
    {
        public unit13_3.Suit Suit
        {
            get { return (unit13_3.Suit)GetValue(SuitProperty); }
            set { SetValue(SuitProperty, value); }
        }
        public static DependencyProperty SuitProperty =
            DependencyProperty.Register("Suit", typeof(unit13_3.Suit), typeof(CardControl), new PropertyMetadata(unit13_3.Suit.Club,
                new PropertyChangedCallback(OnSuitChanged)));
        public unit13_3.Rank Rank
        {
            get { return (unit13_3.Rank)GetValue(RankProperty); }
            set { SetValue(RankProperty, value); }
        }
        public static DependencyProperty RankProperty =
            DependencyProperty.Register("Rank", typeof(unit13_3.Rank), typeof(CardControl), new PropertyMetadata(unit13_3.Rank.Ace));
        public bool IsFaceUp
        {
            get { return (bool)GetValue(IsFaceUpProperty); }
            set { SetValue(IsFaceUpProperty, value); }
        }

        public static readonly DependencyProperty IsFaceUpProperty =
            DependencyProperty.Register("IsFaceUp", typeof(bool), typeof(CardControl), new PropertyMetadata(true,
                new PropertyChangedCallback(OnIsFaceUpChanged)));
        private unit13_3.Card card;
        public unit13_3.Card Card
        {
            get { return card; }
            set { card = value; Suit = card.suit; Rank = card.rank; }
        }
        //当Suit值发生变化时，更改文字颜色
        public static void OnSuitChanged(DependencyObject soure, DependencyPropertyChangedEventArgs args)
        {
            var control = soure as CardControl;
            control.SetTextColor();
        }
        //当IsFaceUp值发生变化时，显示或隐藏控件当前的图片和标签
        public static void OnIsFaceUpChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
        {
            var control = source as CardControl;
            control.RankLable.Visibility = control.SuitLable.Visibility = control.RankLabelInverted.Visibility =
                control.TopRightImage.Visibility = control.BottomLeftImage.Visibility = control.IsFaceUp ?
                Visibility.Visible : Visibility.Hidden;
        }
        public CardControl(unit13_3.Card card)
        {
            InitializeComponent();
            Card = card;
        }
        private void SetTextColor()
        {
            var color = (Suit == unit13_3.Suit.Club || Suit == unit13_3.Suit.Spade) ?
                new SolidColorBrush(Color.FromRgb(0, 0, 0)) :
                new SolidColorBrush(Color.FromRgb(255, 0, 0));
            RankLable.Foreground = SuitLable.Foreground = RankLabelInverted.Foreground = color;
        }
    }
}
