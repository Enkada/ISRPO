using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO_Lab6_A_Lib
{
    public class Shape
    {
        private double area;
        private double perimeter;
        private string name;

        public Shape()
        {
            Area = 0;
            Perimeter = 0;
            Name = "без названия";
        }

        public double Area { get => area; set => area = value; }
        public double Perimeter { get => perimeter; set => perimeter = value; }
        public string Name { get => name; set => name = value; }

        public void Show()
        {
            Console.WriteLine($"Фигура \"{Name}\": S = {Area}, P = {Perimeter}\n");
        }
    }

    public class Rect : Shape
    {
        public double a { get; set; }
        public double b { get; set; }

        public Rect()
        {
            Name = "прямоугольник";
        }

        public Rect(double a, double b)
        {
            this.a = a;
            this.b = b;
            Name = "прямоугольник";
            CalculateArea();
            CalculatePerimeter();
        }

        public void CalculateArea()
        {
            Area = a * b;
        }

        public void CalculatePerimeter()
        {
            Perimeter = 2 * a + 2 * b;
        }
    }

    public class Square : Rect
    {
        public Square()
        {
            Area = 0;
            Perimeter = 0;
            Name = "квадрат";
        }

        public Square(double a)
        {
            this.a = a;
            this.b = a;
            Name = "квадрат";
            CalculateArea();
            CalculatePerimeter();
        }
    }

    public class Circle : Shape
    {
        public double r { get; set; }

        public Circle()
        {
            Area = 0;
            Perimeter = 0;
            Name = "круг";
        }

        public Circle(double r)
        {
            this.r = r;
            Name = "круг";
            CalculateArea();
            CalculatePerimeter();
        }

        public void CalculateArea()
        {
            Area = Math.PI * r * r;
        }

        public void CalculatePerimeter()
        {
            Perimeter = 2 * Math.PI * r;
        }
    }
}
