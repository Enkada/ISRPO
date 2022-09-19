using System;

namespace ISRPO_Lab4
{
    class Angle
    {
        private int degree { get; set; }
        private float minute { get; set; }
        private char direction { get; set; }

        public Angle()
        {
            this.degree = 0;
            this.minute = 0;
            this.direction = 'S';
        }

        public Angle(int degree, float minute, char direction)
        {
            this.degree = degree;
            this.minute = minute;
            this.direction = direction;
        }

        public void Set(int degree, float minute, char direction)
        {
            this.degree = degree;
            this.minute = minute;
            this.direction = direction;
        }

        public void Print()
        {
            Console.WriteLine($"{degree}° {minute}' {direction}");
        }
    }
}
