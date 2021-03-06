﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Tests
{
    [TestFixture]
    public class FigureTests
    {
        [TestCase(6, ExpectedResult = Math.PI * 36)]
        [TestCase(5, ExpectedResult = Math.PI * 25)]
        public double GetArea_Circle_ExpectedPositiveTests(double radius)
        {
            return new Circle(radius).GetArea();
        }

        [TestCase(3, 4, 5, ExpectedResult = 30)]
        public double GetArea_Triangle_ExpectedPositiveTests(double a, double b, double c)
        {
            return new Triangle(a, b, c).GetArea();
        }

        [TestCase(3, 12, ExpectedResult = 36)]
        [TestCase(18, 10, ExpectedResult = 180)]
        public double GetArea_Rectangle_ExpectedPositiveTests(double a, double b)
        {
            return new Rectangle(a, b).GetArea();
        }

        [TestCase(9, ExpectedResult = 81)]
        [TestCase(5, ExpectedResult = 25)]
        public double GetArea_Square_ExpectedPositiveTests(double a)
        {
            return new Square(a).GetArea();
        }

        [TestCase(6, ExpectedResult = Math.PI * 12)]
        [TestCase(5, ExpectedResult = Math.PI * 10)]
        public double GetPerimeter_Circle_ExpectedPositiveTests(double radius)
        {
            return new Circle(radius).GetPerimeter();
        }

        [TestCase(3, 4, 5, ExpectedResult = 12)]
        public double GetPerimeter_Triangle_ExpectedPositiveTests(double a, double b, double c)
        {
            return new Triangle(a, b, c).GetPerimeter();
        }

        [TestCase(3, 12, ExpectedResult = 30)]
        [TestCase(18, 10, ExpectedResult = 56)]
        public double GetPerimeter_Rectangle_ExpectedPositiveTests(double a, double b)
        {
            return new Rectangle(a, b).GetPerimeter();
        }

        [TestCase(9, ExpectedResult = 36)]
        [TestCase(5, ExpectedResult = 20)]
        public double GetPerimeter_Square_ExpectedPositiveTests(double a)
        {
            return new Square(a).GetPerimeter();
        }
    }
}
