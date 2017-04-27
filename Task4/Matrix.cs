using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{    
    public class MatrixEventArgs<T> where T : struct
    {
        public readonly T previousValue;
        public readonly T newValue;

        public MatrixEventArgs(T previousValue, T newValue)
        {
            this.previousValue = previousValue;
            this.newValue = newValue;
        }
    }

    public abstract class Matrix<T> : IEnumerable<T>, IEquatable<Matrix<T>> where T : struct
    {
        protected T[,] innerArray;
        protected virtual void OnElementChanged(MatrixEventArgs<T> e)
            => ElementChanged(this, e);

        public int Size { get; protected set; }
        public event EventHandler<MatrixEventArgs<T>> ElementChanged = delegate { };


        public abstract T this[int i, int j] { get; set; }
        public abstract void Accept(IMatrixVisitor<T> visitor);

        public bool Equals(Matrix<T> other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (ReferenceEquals(null, other))
                return false;

            for (int i = 0; i < Size; i++)
                for (int j = 0; i < Size; j++)
                    if (other[i, j].Equals(innerArray[i, j]))
                        return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (ReferenceEquals(null, obj))
                return false;

            if (GetType() != obj.GetType())
                return false;

            return Equals((Matrix<T>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var element in innerArray)
                    hash = hash * 23 + element.GetHashCode();
                return hash;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; i < Size; j++)
                    yield return innerArray[i, j];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }     
}
