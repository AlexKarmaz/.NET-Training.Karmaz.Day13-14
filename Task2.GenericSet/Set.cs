using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.GenericSet
{
    public class Set<T> : IEnumerable<T>, IEnumerable where T : class
    {
        #region Private Fields
        private IEqualityComparer<T> comparer;
        private int count;
        private List<T> collection;
        #endregion

        #region Properties
        public IEqualityComparer<T> Comparer { get { return this.comparer; } }
        public int Count { get { return this.count; } }
        #endregion

        #region Constructors
        public Set() : this(EqualityComparer<T>.Default){}

        public Set (IEnumerable<T> collection) : this(collection, EqualityComparer<T>.Default){}

        public Set (IEqualityComparer<T> comparer)
        {
            if (comparer == null)
                comparer = EqualityComparer<T>.Default;

            this.count = 0;
            this.comparer = comparer;
            this.collection = new List<T>();
        }

        public Set (IEnumerable<T> collection, IEqualityComparer<T> comparer) : this(comparer)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException(nameof(collection));

            this.UnionWith(collection);
        }

        #endregion

        #region Public Methods
        public bool Add(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            if (!Contains(item))
            {
                this.collection.Add(item);
                this.count = this.collection.Count();
                return true;
            }
            else return false;
            
        }

        public void Clear()
        {
            this.collection.Clear();
            this.count = 0;
        }

        public bool Remove(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));
            if (Contains(item))
            {
                this.collection.Remove(item);
                return true;
            }
            return false;
        }

        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            foreach(T x in this.collection)
            {
                if (this.comparer.Equals(x, item))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException(nameof(array));

            this.collection.CopyTo(array);
        }

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)collection).GetEnumerator();

        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            foreach (T local in other)
            {
                this.Add(local);
            }
        }

        #endregion

        #region Private Members
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}
