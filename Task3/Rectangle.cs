using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Rectangle : Figure
    {
        private double width;
        private double height;        

        public double Width { get { return width; } }
        public double Height { get { return height; } }

        public Rectangle()
        {
            width = 0.0;
            height = 0.0;
        }

        public Rectangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentOutOfRangeException();

            width = a;
            height = b;
        }

        public override double GetArea()
        {
            return width * height;
        }

        public override double GetPerimeter()
        {
            return 2 * (width + height);
        }
    }
}
