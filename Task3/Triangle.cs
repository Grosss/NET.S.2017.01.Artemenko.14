using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Triangle : Figure
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public double A { get { return sideA; } }
        public double B { get { return sideB; } }
        public double C { get { return sideC; } }

        public Triangle()
        {
            sideA = 0.0; 
            sideB = 0.0; 
            sideC = 0.0;
        }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException();

            if (a + b <= c || b + c <= a || a + c <= b)
                throw new ArgumentException();

            sideA = a;
            sideB = b;
            sideC = c;
        }

        public override double GetArea()
        {
            double semiPerimeter = (sideA + sideB + sideC) / 3;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * 
                (semiPerimeter - sideB) * (semiPerimeter - sideC));
        }

        public override double GetPerimeter()
        {
            return sideA + sideB + sideC;
        }
    }
}
