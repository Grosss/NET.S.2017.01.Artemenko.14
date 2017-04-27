using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(5, new int[] { 0, 1, 1, 2, 3 })]
        [TestCase(8, new int[] { 0, 1, 1, 2, 3, 5, 8, 13 })]
        [TestCase(2, new int[] { 0, 1 })]
        public void GetSequence_PassedNumberOfTerms_ExpectedPositiveTest(int termsNumber, int[] array)
        {
            Assert.AreEqual(Fibonacci.GetSequence(termsNumber).ToArray(), array);
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void GetSequence_PassedInvalidNumberOfTerms_ThrowsArgumentOutOfRangeException(int termsNumber)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Fibonacci.GetSequence(termsNumber));
        }
    }
}
