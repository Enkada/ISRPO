using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO_Lab4_B
{
    public class CupOfTea : HotDrink, ICup
    {
        public string LeafType { get; set; } = "черный";
        public double Capacity { get; set; } = 0.2;
        public string Type { get; set; } = "пластик";

        public override void AddMilk(int milk)
        {
            Milk = milk;
            Console.WriteLine($"В чай добавлено молоко: {Milk}");
        }

        public override void AddSugar(int sugar)
        {
            Sugar = sugar;
            Console.WriteLine($"В чай добавлен сахар: {Sugar}");
        }

        public void Refill()
        {
            Console.WriteLine($"Повторить чай объемом {Capacity} мл");
        }

        public void Wash()
        {
            Console.WriteLine($"Вымыть {Type} чашку с чаем");
        }

        public override void Drink()
        {
            Console.WriteLine($"Получите чай: {LeafType}");
        }
    }
}
