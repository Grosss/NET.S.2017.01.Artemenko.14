using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class AddMatrixVisitor<T> : IMatrixVisitor<T> where T : struct
    {
        private Matrix<T> otherMatrix;
        public Matrix<T> ResultMatrix { get; private set; }

        public AddMatrixVisitor(Matrix<T> other)
        {
            otherMatrix = other;
        }

        public void Visit(DiagonalMatrix<T> diagMatrix)
        {
            ResultMatrix = new SquareMatrix<T>(diagMatrix.Size);
            for (int i = 0; i < diagMatrix.Size; i++)
                for (int j = 0; j < diagMatrix.Size; j++)
                    ResultMatrix[i, j] = diagMatrix[i, j] + (dynamic)otherMatrix[i, j];
        }

        public void Visit(SymmetricMatrix<T> symmMatrix)
        {
            ResultMatrix = new SquareMatrix<T>(symmMatrix.Size);
            for (int i = 0; i < symmMatrix.Size; i++)
                for (int j = 0; j < symmMatrix.Size; j++)
                    ResultMatrix[i, j] = symmMatrix[i, j] + (dynamic)otherMatrix[i, j];
        }

        public void Visit(SquareMatrix<T> sqrMatrix)
        {
            ResultMatrix = new SquareMatrix<T>(sqrMatrix.Size);
            for (int i = 0; i < sqrMatrix.Size; i++)
                for (int j = 0; j < sqrMatrix.Size; j++)
                    ResultMatrix[i, j] = sqrMatrix[i, j] + (dynamic)otherMatrix[i, j];
        }
    }
}
