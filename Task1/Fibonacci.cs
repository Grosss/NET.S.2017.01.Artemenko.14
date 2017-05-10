using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class Fibonacci
    {
        public static IEnumerable<int> GetSequence(int termsNumber)
        {
            if (termsNumber < 1)
                throw new ArgumentOutOfRangeException();

            return CalculateSequence(termsNumber);
        }

        private static IEnumerable<int> CalculateSequence(int termsNumber)
        {
            int previousTerm = 0;
            int currentTerm = 1;
            yield return previousTerm;

            for (int i = 0; i < termsNumber - 1; i++)
            {
                yield return currentTerm;
                currentTerm = previousTerm + currentTerm;
                previousTerm = currentTerm - previousTerm;
            }
        }
    }
}
