using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using ISRPO_Lab6_B_Lib;

namespace ISRPO_Lab6_B_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();

        public MainWindow()
        {
            InitializeComponent();
            UpdateDeck();
        }

        public void UpdateDeck()
        {
            wpDeck.Children.Clear();
            for (int i = 0; i < 52; i++)
            {
                TextBlock card = GetCardTextBlock(deck.GetCard(i));

                wpDeck.Children.Add(card);
            }
        }

        public TextBlock GetCardTextBlock(Card card)
        {
            TextBlock textBlock = new TextBlock();

            int code = 0;
            switch (card.Rank)
            {
                case int n when (n <= 11):
                    code = 0x1F0A0 + card.Rank;
                    break;
                case int n when (n == 12):
                    code = 0x1F0A0 + 13;
                    break;
                case int n when (n == 13):
                    code = 0x1F0A0 + 14;
                    break;
            }

            // трефы (♣), бубны (♦), червы (♥) и пики (♠)
            switch (card.Suit)
            {
                case '♦':
                    code += 0x00020;
                    textBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    break;
                case '♥':
                    code += 0x00010;
                    textBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    break;
                case '♣':
                    code += 0x00030;
                    break;
            }
            //int code = card.Rank != 12 ? 0x1F0A0 + card.Rank : 0x1F0A0 + 14;

            string symbol = char.ConvertFromUtf32(code);
            textBlock.Text = symbol;

            return textBlock;
        }

        private void btnShuffle_Click(object sender, RoutedEventArgs e)
        {
            deck.Shuffle();
            UpdateDeck();
        }
    }
}
