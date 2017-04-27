using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Tests
{
    [TestFixture]
    public class AddMatrixVisitorTests
    {
        #region Matrixes

        public readonly int[,] sqrMatrix =
            new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

        public readonly int[,] symmMatrix =
            new int[3, 3]
            {
                { 1, 2, 3 },
                { 2, 5, 6 },
                { 3, 6, 9 }
            };

        public readonly int[,] diagMatrix =
            new int[3, 3]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };

        public readonly int[,] sqrPlusSqrMatrix =
            new int[3, 3]
            {
                { 2, 4, 6 },
                { 8, 10, 12 },
                { 14, 16, 18 }
            };

        public readonly int[,] sqrPlusSymmMatrix =
            new int[3, 3]
            {
                { 2, 4, 6 },
                { 6, 10, 12 },
                { 10, 14, 18 }
            };

        public readonly int[,] sqrPlusDiagMatrix =
            new int[3, 3]
            {
                { 2, 2, 3 },
                { 4, 6, 6 },
                { 7, 8, 10 }
            };

        public readonly int[,] diagPlusSymmMatrix =
            new int[3, 3]
            {
                { 2, 2, 3 },
                { 2, 6, 6 },
                { 3, 6, 10 }
            };

        #endregion

        [TestCase(ExpectedResult = true)]
        public bool Sum_PassedSquareAndSquareMatrixes_ExpectedPositiveTest()
        {
            Matrix<int> squareMatrix = new SquareMatrix<int>(3);
            Matrix<int> anotherSquareMatrix = new SquareMatrix<int>(3);
            Matrix<int> resultMatrix = new SquareMatrix<int>(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    squareMatrix[i, j] = sqrMatrix[i, j];
                    anotherSquareMatrix[i, j] = sqrMatrix[i, j];
                    resultMatrix[i, j] = sqrPlusSqrMatrix[i, j];
                }
            }

            return (squareMatrix.Sum(anotherSquareMatrix)).Equals(resultMatrix);
        }

        [TestCase(ExpectedResult = true)]
        public bool Sum_PassedSquareAndSymmetricMatrixes_ExpectedPositiveTest()
        {
            Matrix<int> squareMatrix = new SquareMatrix<int>(3);
            Matrix<int> symmetricMatrix = new SquareMatrix<int>(3);
            Matrix<int> resultMatrix = new SquareMatrix<int>(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    squareMatrix[i, j] = sqrMatrix[i, j];
                    symmetricMatrix[i, j] = symmMatrix[i, j];
                    resultMatrix[i, j] = sqrPlusSymmMatrix[i, j];
                }
            }

            return (squareMatrix.Sum(symmetricMatrix)).Equals(resultMatrix);
        }

        [TestCase(ExpectedResult = true)]
        public bool Sum_PassedSquareAndDiagonalMatrixes_ExpectedPositiveTest()
        {
            Matrix<int> squareMatrix = new SquareMatrix<int>(3);
            Matrix<int> diagonalMatrix = new SquareMatrix<int>(3);
            Matrix<int> resultMatrix = new SquareMatrix<int>(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    squareMatrix[i, j] = sqrMatrix[i, j];
                    diagonalMatrix[i, j] = diagMatrix[i, j];
                    resultMatrix[i, j] = sqrPlusDiagMatrix[i, j];
                }
            }

            return (squareMatrix.Sum(diagonalMatrix)).Equals(resultMatrix);
        }

        [TestCase(ExpectedResult = true)]
        public bool Sum_PassedDiagonalAndSymmetricMatrixes_ExpectedPositiveTest()
        {
            Matrix<int> symmetricMatrix = new SquareMatrix<int>(3);
            Matrix<int> diagonalMatrix = new SquareMatrix<int>(3);
            Matrix<int> resultMatrix = new SquareMatrix<int>(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    symmetricMatrix[i, j] = symmMatrix[i, j];
                    diagonalMatrix[i, j] = diagMatrix[i, j];
                    resultMatrix[i, j] = diagPlusSymmMatrix[i, j];
                }
            }

            return (symmetricMatrix.Sum(diagonalMatrix)).Equals(resultMatrix);
        }
    }
}
