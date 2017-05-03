using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private  T[,] array;

        #region Constructors
        public SquareMatrix()
        {
            Size = 1;
            array = new T[Size, Size];
            array[0, 0] = default(T);
        }

        public SquareMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
            array = new T[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    array[i, j] = default(T);
            }

        }

        public SquareMatrix(T[,] baseArray)
        {
            if (baseArray == null)
                throw new ArgumentNullException(nameof(baseArray));
            if (baseArray.GetLength(0) != baseArray.GetLength(1))
                throw new ArgumentException($"{nameof(baseArray)} doesn't square array");

            Size = baseArray.GetLength(0);
            array = new T[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    array[i, j] = baseArray[i, j];
            }
        }
        #endregion

        #region Public Methods
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return this[i, j];
        }

        public override T GetValue(int i, int j)
        {
            if (i < 0 || i > Size)
                throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Size)
                throw new ArgumentOutOfRangeException(nameof(j));

            return array[i, j];
        }

        public override void SetValue(int i, int j, T value)
        {
            if (i < 0 || i > Size)
                throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Size)
                throw new ArgumentOutOfRangeException(nameof(j));
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException(nameof(value));

            array[i, j] = value;
        }

        public override int GetHashCode() => array?.GetHashCode() ?? 0;
        #endregion
    }
}
