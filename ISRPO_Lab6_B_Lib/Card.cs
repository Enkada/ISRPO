using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO_Lab6_B_Lib
{
    public class Card
    {
        private char suit;
        private int rank;

        public int Rank { get => rank; set => rank = value; }
        public char Suit { get => suit; set => suit = value; }

        private Card() { }

        public Card(char suit, int rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public override string ToString()
        {
            return $"{Rank}{Suit}";
        }
    }
}
