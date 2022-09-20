using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO_Lab6_B_Lib
{
    public class Deck
    {
        Card[] cards;

        // трефы (♣), бубны (♦), червы (♥) и пики (♠)
        char[] suits = new char[] { '♣', '♦', '♥', '♠' };

        public Deck()
        {
            cards = new Card[52];
                        
            for (int suit = 0; suit < suits.Length; suit++)
            {
                for (int i = 1; i <= 13; i++)
                {
                    cards[(i - 1) + 13 * suit] = new Card(suits[suit], i);
                }
            }
        }

        public void SetCard(int i, char suit, int rank)
        {
            cards[i] = new Card(suit, rank);
        }

        public Card GetCard(int i)
        {
            return cards[i];
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            cards = cards.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}
