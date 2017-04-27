using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Circle : Figure
    {
        private double radius;

        public double Radius { get { return radius; } }

        public Circle()
        {
            radius = 0.0;
        }

        public Circle(double r)
        {
            if (r <= 0)
                throw new ArgumentOutOfRangeException();

            radius = r;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
}
