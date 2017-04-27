using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface IMatrixVisitor<T> where T : struct
    {
        void Visit(SquareMatrix<T> sqrMatrix);
        void Visit(SymmetricMatrix<T> symmMatrix);
        void Visit(DiagonalMatrix<T> diagMatrix);
    }
}
