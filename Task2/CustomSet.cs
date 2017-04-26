using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class CustomSet<T> : IEnumerable<T>, ISet<T> where T : class // ISet<T>
    {
        private List<T> collection;
        private readonly IEqualityComparer<T> comparer;

        public int Count { get { return collection.Count; } }

        #region Constructors

        public CustomSet() : this(new List<T>(), EqualityComparer<T>.Default)
        { }

        public CustomSet(IEqualityComparer<T> comparer) : this(new List<T>(), comparer)
        { }

        public CustomSet(IEnumerable<T> collection) : this(collection, EqualityComparer<T>.Default)
        { }

        public CustomSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException();

            if (ReferenceEquals(comparer, null))
                this.comparer = EqualityComparer<T>.Default;
            else
                this.comparer = comparer;

            this.collection = new List<T>(collection);
        }

        #endregion

        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();

            foreach (T element in other)
                Add(element);
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();

            var newSet = new List<T>();
            foreach(var element in other)
            {
                if (collection.Contains(element))
                    newSet.Add(element);
            }

            collection = new List<T>(newSet);
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var element in other)
            {
                if (collection.Contains(element))
                    collection.Remove(element);
            }
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            
            foreach (var element in other)
            {
                if (!collection.Contains(element))
                    collection.Add(element);
                else
                    collection.Remove(element);
            }
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();

            foreach (var element in collection)
            {
                if (!other.Contains(element))
                    return false;
            }

            return true;
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();

            foreach (var element in other)
            {
                if (!collection.Contains(element))
                    return false;
            }

            return true;
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return IsSupersetOf(other) && !SetEquals(other);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return IsSubsetOf(other) && !SetEquals(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();

            
            foreach (T element in other)
            {
                if (collection.Contains(element))
                    return true;
            }
            
            return false;
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return IsSubsetOf(other) && IsSupersetOf(other);
        }

        public bool Add(T item)
        {
            if (collection.Contains(item))
                return false;

            collection.Add(item);
            return true;
        }

        public bool Remove(T item)
        {
            return collection.Remove(item);
        }

        public void Clear()
        {
            collection.Clear();
        }

        public bool Contains(T item)
        {
            return collection.Contains(item);
        }

        public void CopyTo(T[] array)
            => CopyTo(array, 0, collection.Count);

        public void CopyTo(T[] array, int index)
            => CopyTo(array, index, collection.Count);

        public void CopyTo(T[] array, int index, int count)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (index < 0 || count < 0)
                throw new ArgumentOutOfRangeException();
            
            if ((index > array.Length) || (count > (array.Length - index)))
                throw new ArgumentException();

            collection.CopyTo(0, array, index, count);
        }       

        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        #region Private members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        void ICollection<T>.Add(T item)
        {
            Add(item);
        }
                
        bool ICollection<T>.IsReadOnly { get { return false; } }

        #endregion
    }
}
