﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.GenericSet
{
    public class Set<T> : IEnumerable<T> where T : class, IEquatable<T>
    {
        #region Private Fields
        private IEqualityComparer<T> comparer;
        private int count;
        private T[] collection;
        #endregion

        #region Properties
        public IEqualityComparer<T> Comparer { get { return this.comparer; } }
        public int Count { get { return this.count; } private set { count = value; } }
        public int Capacity => collection.Length;
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
            this.collection = new T[10];
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

            if (Count == Capacity)
                SetCapacity(Capacity * 2);

            if (!Contains(item))
            {
                collection[Count++] = item;
                return true;
            }
            else return false;
            
        }

        public void Clear()
        {
            Array.Clear(collection,0,Count);
            this.count = 0;
        }

        public bool Remove(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));
            if (Contains(item))
            {
                for (int i = 0; i < Count; i++)
                    if (comparer.Equals(collection[i], item))
                    {
                        Array.ConstrainedCopy(collection, i + 1, collection, i, Count - i - 1);
                        Count--;
                        return true;
                    }
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

            Array.ConstrainedCopy(collection, 0, array, 0, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in collection)
                yield return element;
        }

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
        private void SetCapacity(int capacity) => Array.Resize(ref collection, capacity);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}
