using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{    
    public class MatrixEventArgs<T> : EventArgs where T : struct
    {
        public readonly T previousValue;
        public readonly T newValue;
        public readonly int row;
        public readonly int column;

        public MatrixEventArgs(T previousValue, T newValue, int row, int column)
        {
            this.previousValue = previousValue;
            this.newValue = newValue;
            this.row = row;
            this.column = column;
        }
    }

    public abstract class Matrix<T> : IEnumerable<T> where T : struct
    {
        protected virtual void OnElementChanged(MatrixEventArgs<T> e)
            => ElementChanged(this, e);

        public int Size { get; protected set; }
        public event EventHandler<MatrixEventArgs<T>> ElementChanged = delegate { };
                
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                    throw new ArgumentOutOfRangeException();

                return GetValue(i, j);
            }

            set
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                    throw new ArgumentOutOfRangeException();
                
                OnElementChanged(new MatrixEventArgs<T>(GetValue(i, j), value, i, j));
                SetValue(i, j, value);
            }
        }
                
        public abstract void Accept(IMatrixVisitor<T> visitor);        
        public abstract IEnumerator<T> GetEnumerator();

        protected abstract T GetValue(int i, int j);
        protected abstract void SetValue(int i, int j, T value);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }     
}
