using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISRPO_Lab6_B_Lib;

namespace ISRPO_Lab6_B_Console
{
    internal class Program
    {
        static void Main()
        {
            Deck deck = new Deck();

            bool run = true;
            while (run)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Write("Выберите действие (1) показать колоду, (2) перетасовать колоду, (3) выход: ");
                int action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        for (int i = 0; i < 52; i++)
                        {
                            if (i % 13 == 0)
                                Console.WriteLine();
                            Console.Write(deck.GetCard(i) + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        deck.Shuffle();
                        Console.WriteLine("Колода перетасована");
                        break;
                    case 3:
                        run = false;
                        break;
                }
            }
        }
    }
}
