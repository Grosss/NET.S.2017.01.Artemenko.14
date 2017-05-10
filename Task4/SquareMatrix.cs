using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SquareMatrix<T> : Matrix<T> where T : struct
    {
        private T[,] innerArray;

        public SquareMatrix() : this(4)
        { }

        public SquareMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException();

            Size = size;
            innerArray = new T[size, size];
        }

        public SquareMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();

            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException();

            Size = array.GetLength(0);
            innerArray = new T[Size, Size];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    innerArray[i, j] = array[i, j];
        }
                
        public override void Accept(IMatrixVisitor<T> visitor)
            => visitor.Visit(this);

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return innerArray[i, j];
        }

        protected override T GetValue(int i, int j)
            => innerArray[i, j];

        protected override void SetValue(int i, int j, T value)
            => innerArray[i, j] = value;    
    }
}
