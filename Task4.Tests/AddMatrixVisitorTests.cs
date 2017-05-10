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
        
        [Test]
        public void Sum_PassedSquareAndSquareMatrixes_ExpectedPositiveTest()
        {
            Matrix<int> squareMatrix = new SquareMatrix<int>(sqrMatrix);
            Matrix<int> anotherSquareMatrix = new SquareMatrix<int>(sqrMatrix);
            Matrix<int> resultMatrix = new SquareMatrix<int>(sqrPlusSqrMatrix);
                        
            Assert.AreEqual(squareMatrix.Sum(squareMatrix), resultMatrix);
        }

        [Test]
        public void Sum_PassedSquareAndSymmetricMatrixes_ExpectedPositiveTest()
        {
            Matrix<int> squareMatrix = new SquareMatrix<int>(sqrMatrix);
            Matrix<int> symmetricMatrix = new SymmetricMatrix<int>(symmMatrix);
            Matrix<int> resultMatrix = new SquareMatrix<int>(sqrPlusSymmMatrix);
            
            Assert.AreEqual(squareMatrix.Sum(symmetricMatrix), resultMatrix);
        }

        [Test]
        public void Sum_PassedSquareAndDiagonalMatrixes_ExpectedPositiveTest()
        {
            Matrix<int> squareMatrix = new SquareMatrix<int>(sqrMatrix);
            Matrix<int> diagonalMatrix = new SquareMatrix<int>(diagMatrix);
            Matrix<int> resultMatrix = new SquareMatrix<int>(sqrPlusDiagMatrix);
            
            Assert.AreEqual(squareMatrix.Sum(diagonalMatrix), resultMatrix);
        }

        [Test]
        public void Sum_PassedDiagonalAndSymmetricMatrixes_ExpectedPositiveTest()
        {
            Matrix<int> symmetricMatrix = new SquareMatrix<int>(symmMatrix);
            Matrix<int> diagonalMatrix = new SquareMatrix<int>(diagMatrix);
            Matrix<int> resultMatrix = new SquareMatrix<int>(diagPlusSymmMatrix);
            
            Assert.AreEqual(symmetricMatrix.Sum(diagonalMatrix), resultMatrix);
        }
    }
}
