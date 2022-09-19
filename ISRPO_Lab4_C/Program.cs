using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO_Lab4_C
{
    struct Orders
    {
        public string itemName; // наименование
        public int unitCount;   // число единиц
        public double unitCost; // стоимость одной единицы

        public double GetUnitPrice()
        {
            return unitCount * unitCost;
        }
    }


    class Program
    {
        static void Main()
        {
            Orders order1 = new Orders() { itemName = "Заказ1", unitCount = 5, unitCost = 14.5 };
            Orders order2 = new Orders() { itemName = "Заказ2", unitCount = 17, unitCost = 3.15 };

            Console.WriteLine($"Стоимость заказа \"{order1.itemName}\": {order1.GetUnitPrice()}");
            Console.WriteLine($"Стоимость заказа \"{order2.itemName}\": {order2.GetUnitPrice()}");

            Console.Read();
        }
    }
}
