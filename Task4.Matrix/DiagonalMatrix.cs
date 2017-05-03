using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private T[] array;

        #region Constructors
        public DiagonalMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            Size = size;
            array = new T[Size];
            for (int i = 0; i < Size; i++)
            {
                    array[i] = default(T);
            }
        }

        public DiagonalMatrix(T[,] baseArray)
        {
            if (baseArray == null)
                throw new ArgumentNullException(nameof(baseArray));
            if (baseArray.GetLength(0) != baseArray.GetLength(1))
                throw new ArgumentException($"{nameof(baseArray)} doesn't square array");
            if (!CheckDiagonal(baseArray))
                throw new ArgumentException($"{nameof(baseArray)} doesn't symmetric matrix");

            Size = baseArray.GetLength(0);
            array = new T[Size];
            for (int i = 0; i < Size; i++)
            {
                    array[i] = baseArray[i, i];
            }
        }
        #endregion

        #region Private Methods
        private bool CheckDiagonal(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            int size = array.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                        if (!array[i, j].Equals(default(T)))
                            return false;
                }
            }
            return true;
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


            return i == j ? array[i] : default(T);
        }


        public override void SetValue(int i, int j, T value)
        {
            if (i < 0 || i > Size)
                throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Size)
                throw new ArgumentOutOfRangeException(nameof(j));
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException(nameof(value));

            if (i == j)
                array[i] = value;
            else
                throw new ArgumentException("We try to set value on non-diagonal line");
        }

        public override int GetHashCode() => array?.GetHashCode() ?? 0;
        #endregion
    }
}
