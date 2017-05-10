using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SymmetricMatrix<T> : Matrix<T> where T : struct
    {
        private T[][] innerArray;

        public SymmetricMatrix() : this(4)
        { }

        public SymmetricMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException();

            Size = size;
            innerArray = new T[Size][];
            for (int i = 0; i < Size; i++)
            {
                innerArray[i] = new T[i + 1];
            }
        }

        public SymmetricMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();

            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException();

            Size = array.GetLength(0);
            innerArray = new T[Size][];

            for (int i = 0; i < Size; i++)
            {
                innerArray[i] = new T[i + 1];
                for (int j = 0; j < innerArray[i].Length; j++)
                    innerArray[i][j] = array[i, j];
            }
        }

        public override void Accept(IMatrixVisitor<T> visitor)
            => visitor.Visit(this);

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < innerArray[i].Length; j++)
                    yield return innerArray[i][j];

                for (int j = innerArray[i].Length; j < Size; j++)
                    yield return innerArray[j][i];
            }
        }

        protected override T GetValue(int i, int j)
        {
            if (i < j)
                return innerArray[j][i];
            else
                return innerArray[i][j];
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i != j)
                throw new ArgumentException();

            innerArray[i][j] = value;
        }
    }
}
