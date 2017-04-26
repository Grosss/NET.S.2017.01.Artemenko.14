using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Square : Figure
    {
        private double side;

        public double Side { get { return side; } }

        public Square()
        {
            side = 0.0;
        }

        public Square(double a)
        {
            if (a <= 0)
                throw new ArgumentOutOfRangeException();

            side = a;
        }

        public override double GetArea()
        {
            return side * side;
        }

        public override double GetPerimeter()
        {
            return 4 * side;
        }
    }
}
