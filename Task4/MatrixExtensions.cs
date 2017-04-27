using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class MatrixExtensions
    {
        public static Matrix<T> Sum<T>(this Matrix<T> matrix, Matrix<T> other) where T : struct
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException();

            var visitor = new AddMatrixVisitor<T>(other);
            matrix.Accept(visitor);
            return visitor.ResultMatrix;
        }
    }
}
