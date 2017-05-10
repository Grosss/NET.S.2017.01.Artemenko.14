using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class DiagonalMatrix<T> : Matrix<T> where T : struct
    {
        private T[] innerArray;

        public DiagonalMatrix() : this(4)
        { }

        public DiagonalMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException();

            Size = size;
            innerArray = new T[size];
        }

        public DiagonalMatrix(T[] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();

            Size = array.Length;
            innerArray = new T[Size];

            for (int i = 0; i < Size; i++)
                innerArray[i] = array[i];
        }

        public override void Accept(IMatrixVisitor<T> visitor)
            => visitor.Visit(this);

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    if (i != j)
                        yield return default(T);
                    else
                        yield return innerArray[i];
                }
        }

        protected override T GetValue(int i, int j)
        {
            if (i == j)
                return innerArray[i];
            else
                return default(T);
        }            

        protected override void SetValue(int i, int j, T value)
        {
            if (i != j)
                throw new ArgumentException();

            innerArray[i] = value;
        }
    }
}
