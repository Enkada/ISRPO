using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISRPO_Lab6_A_Lib;

namespace ISRPO_Lab6_A
{
    internal class Program
    {
        static void Main()
        {
            Shape shape = new Shape();

            bool run = true;
            while (run)
            {
                Console.Write("Выберите тип фигуры (1) прямоугольник, (2) круг, (3) квадрат, (4) выход: ");
                int shapeType = int.Parse(Console.ReadLine());

                switch (shapeType)
                {
                    case 1:
                        Console.Write("Введите длину стороны а: ");
                        double rectA = double.Parse(Console.ReadLine());

                        Console.Write("Введите длину стороны b: ");
                        double rectB = double.Parse(Console.ReadLine());

                        shape = new Rect(rectA, rectB);
                        break;
                    case 2:
                        Console.Write("Введите радиус r: ");
                        double circleR = double.Parse(Console.ReadLine());

                        shape = new Circle(circleR);
                        break;
                    case 3:
                        Console.Write("Введите длину стороны: ");
                        double squareA = double.Parse(Console.ReadLine());

                        shape = new Square(squareA);
                        break;
                    case 4:
                    default:
                        run = false;
                        break;
                }

                shape.Show();

            }
        }
    }
}
