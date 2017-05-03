using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public abstract class Matrix<T> : IEquatable<Matrix<T>>, IEnumerable<T>
    {
        #region Public members
        public event EventHandler<MatrixEventArgs> Update = delegate { };

        public int Size { get; protected set; }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 && i >= Size)
                    throw new ArgumentOutOfRangeException(nameof(i));
                if (j < 0 && j >= Size)
                    throw new ArgumentOutOfRangeException(nameof(j));
                return GetValue(i, j);
            }
            set
            {
                if (i < 0 && i >= Size)
                    throw new ArgumentOutOfRangeException(nameof(i));
                if (j < 0 && j >= Size)
                    throw new ArgumentOutOfRangeException(nameof(j));

                SetValue(i, j, value);
                OnUpdate(this, new MatrixEventArgs(i, j));
            }
        }

        public void Accept(IMatrixVisitor<T> visitor, Matrix<T> matrix)
        {
            if (ReferenceEquals(visitor, null))
                throw new ArgumentNullException(nameof(visitor));
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException(nameof(matrix));

            visitor.Visit((dynamic)this, matrix);
        }

        public bool Equals(Matrix<T> other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Size == other.Size && EqualsByIndexator(other);
        }

        public abstract T GetValue(int i, int j);
        public abstract void SetValue(int i, int j, T value);
        public abstract IEnumerator<T> GetEnumerator();
        #endregion

        #region Overridden System.Object methods
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType() && !obj.GetType().IsSubclassOf(typeof(Matrix<T>)))
                return false;
            return EqualsByIndexator((Matrix<T>)obj);
        }

        public override abstract int GetHashCode();

        public override string ToString()
        {
            StringBuilder matrixBuilder = new StringBuilder();
            matrixBuilder.Append($"Matrix. Size: {Size}\n");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrixBuilder.Append($"{this[i, j]} ");
                }
                matrixBuilder.Append("\n");
            }
            return matrixBuilder.ToString();
        }
        #endregion

        #region Protected methods
        protected bool EqualsByIndexator(Matrix<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (!this[i, j].Equals(other[i, j]))
                        return false;

            return true;
        }

        protected void OnUpdate(object sender, MatrixEventArgs e)
        {
            var update = Update;
            update?.Invoke(sender, e);
        }
        #endregion

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
