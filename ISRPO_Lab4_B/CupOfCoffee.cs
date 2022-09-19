using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO_Lab4_B
{
    public class CupOfCoffee : HotDrink, ICup
    {
        public string BeanType { get; set; } = "арабика";
        public double Capacity { get; set; } = 0.2;
        public string Type { get; set; } = "пластик";

        public override void AddMilk(int milk)
        {
            Milk = milk;
            Console.WriteLine($"В кофе добавлено молоко: {Milk}");
        }

        public override void AddSugar(int sugar)
        {
            Sugar = sugar;
            Console.WriteLine($"В кофе добавлен сахар: {Sugar}");
        }

        public void Refill()
        {
            Console.WriteLine($"Повторить кофе объемом {Capacity} мл");
        }

        public void Wash()
        {
            Console.WriteLine($"Вымыть {Type} чашку с кофе");
        }

        public override void Drink()
        {
            Console.WriteLine($"Получите кофе: {BeanType}");
        }
    }
}
