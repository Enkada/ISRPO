using System;

namespace ISRPO_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Angle a = new Angle(10, 20, 'W');
            Console.WriteLine("Angle A:");
            a.Print();

            Angle b = new Angle();
            b.Set(22, 33, 'N');
            Console.WriteLine("\nAngle B:");
            b.Print();

            Console.ReadKey();
        }
    }
}
