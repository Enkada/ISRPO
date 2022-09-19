using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO_Lab4_B
{
    class Program
    {
        static int milk;
        static int sugar;

        static void Main()
        {
            HotDrink drink;
            Console.Write("Выберете напиток: кофе (1) или чай (2): ");
            int drinkType = Convert.ToInt32(Console.ReadLine());

            if (drinkType == 1)
            {
                drink = new CupOfCoffee();
                Console.WriteLine("Тип зерен: арабика или робуста (по умолч. арабика);");
            }
            else
            {
                drink = new CupOfTea();
                Console.WriteLine("Тип чая: зеленый или черный (по умолч. черный);");
            }

            Console.WriteLine("Сахар: 0...5 (по умолч. 3);");
            Console.WriteLine("Молоко: 0...10 (по умолч. 3);");
            Console.WriteLine("Тип стакана: пластик или стекло (по умолч. пластик);");
            Console.WriteLine("Объем: 0,2 или 0,3 (по умолч. 0,2)");

            if (drinkType == 1)
                Console.Write("\n Тип зерен: ");
            else
                Console.Write("\n Тип чая: ");

            string type = Console.ReadLine();

            if (drink is CupOfCoffee coffee)
                coffee.BeanType = type;
            else if (drink is CupOfTea tea)
                tea.LeafType = type;

            Console.Write("\n Молоко: ");
            milk = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n Cахар: ");
            sugar = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n Тип стакана: ");
            string cupType = Console.ReadLine();
            (drink as ICup).Type = cupType;

            Console.Write("\n Объем (мл): ");
            double capacity = Convert.ToDouble(Console.ReadLine());
            (drink as ICup).Capacity = capacity;
            Console.WriteLine("----------------");

            ProcessCup(drink);
            Console.ReadKey();
        }

        public static void ProcessCup(HotDrink drink)
        {
            drink.AddMilk(milk);
            drink.AddSugar(sugar);
            drink.Drink();

            if (drink is ICup cup)
            {
                cup.Wash();
                cup.Refill();
            }
        }
    }
}
