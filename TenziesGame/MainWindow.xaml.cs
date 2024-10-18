using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TenziesGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int NumDice = 10;
        private List<Dice> _diceList;
        public MainWindow()
        {
            InitializeComponent();
            _diceList = new List<Dice>();
            CreateTenziesUI();
        }

        private void CreateTenziesUI()
        {
            for (int i = 0; i < NumDice; i++)
            {
                Dice dice = new Dice(i);
                _diceList.Add(dice);

                // Create a TextBlock to represent a die face
                TextBlock diceText = new()
                {
                    Text = dice.DiceNum.ToString(),  // Default value (initial dice face)
                    FontSize = 36,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                Button diceButton = new()
                {
                    Content = diceText,
                    Padding = new Thickness(10),
                    Margin = new Thickness(5),

                };

                // need to add click event handler
                diceButton.Click += (sender, e) =>
                {
                    // toggle state when dice is clicked
                    dice.IsFixed = !dice.IsFixed;

                    if (dice.IsFixed)
                    {
                        diceButton.Background = Brushes.Green;
                    }
                    else
                    {
                        diceButton.Background = Brushes.White;
                    }

                    CheckWinning();
                };

                DiceContainer.Children.Add(diceButton);
            }
        }

        private void CheckWinning()
        {
            int checkValue = _diceList[0].DiceNum;
            for (int i = 0; i < NumDice; i++)
            {
                Dice dice = _diceList[i];
                // all dice should be fixed and must have the same value
                if (!dice.IsFixed || dice.DiceNum != checkValue)
                {
                    return;
                }
            }

            MessageBox.Show("You Have Won!!");


        }

        private void RollButtonClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < NumDice; i++)
            {
                Dispatcher.Invoke(() => {
                    Dice dice = _diceList[i];
                    dice.RollDice();
                    Button diceButton = (Button)DiceContainer.Children[i];
                    TextBlock diceText = (TextBlock)diceButton.Content;

                    diceText.Text = dice.DiceNum.ToString();

                });
            }

            CheckWinning();
        }
    }
}