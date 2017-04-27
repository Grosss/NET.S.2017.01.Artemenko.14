using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SymmetricMatrix<T> : Matrix<T> where T : struct
    {
        public SymmetricMatrix() : this(4)
        { }

        public SymmetricMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException();

            Size = size;
            innerArray = new T[size, size];
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                    throw new ArgumentOutOfRangeException();

                return innerArray[i, j];
            }

            set
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                    throw new ArgumentOutOfRangeException();

                OnElementChanged(new MatrixEventArgs<T>(innerArray[i, j], value));
                OnElementChanged(new MatrixEventArgs<T>(innerArray[j, i], value));
                innerArray[i, j] = value;
                innerArray[j, i] = value;
            }
        }

        public override void Accept(IMatrixVisitor<T> visitor)
            => visitor.Visit(this);
    }
}
