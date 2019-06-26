using System.Windows;
using System.Windows.Input;

namespace KarliCards.Gui
{
    /// <summary>
    /// GameClientWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GameClientWindow : Window
    {
        public GameClientWindow()
        {
            InitializeComponent();
            /*var position = new Point(15, 15);
            for (var i = 0; i < 4; i++)
            {
                var suit = (unit13_3.Suit)i;
                position.Y = 15;
                for (int rank = 1; rank < 14; rank++)
                {
                    position.Y += 30;
                    var card = new CardControl(new unit13_3.Card((unit13_3.Suit)suit, (unit13_3.Rank)rank));
                    card.VerticalAlignment = VerticalAlignment.Top;
                    card.HorizontalAlignment = HorizontalAlignment.Left;
                    card.Margin = new Thickness(position.X, position.Y, 0, 0);
                }
                position.X += 112;
            }*/
        }
        //是否对用户可用
        private void CommandCanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Close)
                e.CanExecute = true;
            if (e.Command == ApplicationCommands.Save)
                e.CanExecute = false;
            if (e.Command == GameViewModel.StartGameCommand)
                e.CanExecute = true;
            if (e.Command == GameOptions.OptionsCommand)
                e.CanExecute = true;
            if (e.Command == GameViewModel.ShowAboutCommand)
                e.CanExecute = true;
            e.Handled = true;
        }
        //在用户激活命令时调用
        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Close)
                this.Close();
            if (e.Command == GameViewModel.StartGameCommand)
            {
                var model = new GameViewModel();
                var startGameDialog = new StartGameWindow();
                var options = GameOptions.Create();
                startGameDialog.DataContext = options;
                var result = startGameDialog.ShowDialog();
                if (result.HasValue && result.Value == true)
                {
                    options.Save();
                    model.StartNewGame();
                    DataContext = model;
                }
            }
            if (e.Command == GameOptions.OptionsCommand)
            {
                var dialog = new OptionsWindow();
                var result = dialog.ShowDialog();
                if (result.HasValue && result.Value == true)
                    DataContext = new GameViewModel();
            }
            if (e.Command == GameViewModel.ShowAboutCommand)
            {
                var dialog = new AboutWindow();
                dialog.ShowDialog();
            }
            e.Handled = true;
        }
    }
}
