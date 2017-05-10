using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sqrMatrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] symmMatrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 2, 5, 6 },
                { 3, 6, 9 }
            };
            int[,] sqrPlusSymmMatrix = new int[3, 3]
            {
                { 2, 4, 6 },
                { 6, 10, 12 },
                { 10, 14, 18 }
            };

            Matrix<int> squareMatrix = new SquareMatrix<int>(sqrMatrix);
            Matrix<int> symmetricMatrix = new SquareMatrix<int>(symmMatrix);

            foreach(var x in squareMatrix)
                Console.WriteLine(x);
            squareMatrix.Sum(symmetricMatrix);
            foreach (var x in squareMatrix)
                Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}
