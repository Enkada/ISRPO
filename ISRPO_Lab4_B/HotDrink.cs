using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO_Lab4_B
{
    public abstract class HotDrink
    {
        private int milk;
        private int sugar;

        public int Milk { get => milk; set => milk = value; }
        public int Sugar { get => sugar; set => sugar = value; }

        public abstract void Drink();

        public abstract void AddMilk(int n);
        public abstract void AddSugar(int n);
    }
}
