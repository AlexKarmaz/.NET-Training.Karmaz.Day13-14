using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public class MatrixSumVisitor<T> : IMatrixVisitor<T>
    {
        #region Public Members
        public Matrix<T> Result { get; private set; }

        public void Visit(SquareMatrix<T> matrix, Matrix<T> addMatrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (addMatrix == null)
                throw new ArgumentNullException(nameof(addMatrix));
            if (matrix.Size != addMatrix.Size)
                throw new ArgumentException("Matrix sizes doesn't match");

            AddMatrix(matrix, addMatrix);
        }

        public void Visit(SymmetricMatrix<T> matrix, Matrix<T> addMatrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (addMatrix == null)
                throw new ArgumentNullException(nameof(addMatrix));
            if (matrix.Size != addMatrix.Size)
                throw new ArgumentException("Matrix sizes doesn't match");

            AddMatrix(matrix, addMatrix);
        }

        public void Visit(DiagonalMatrix<T> matrix, Matrix<T> addMatrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (addMatrix == null)
                throw new ArgumentNullException(nameof(addMatrix));
            if (matrix.Size != addMatrix.Size)
                throw new ArgumentException("Matrix sizes doesn't match");

            AddMatrix(matrix, addMatrix);
        }
        #endregion

        private void AddMatrix(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Size != secondMatrix.Size)
                throw new ArgumentException("The matrix have different sizes");
            try
            {
                Result = new SquareMatrix<T>(firstMatrix.Size);
                for (int i = 0; i < firstMatrix.Size; i++)
                    for (int j = 0; j < firstMatrix.Size; j++)
                    {
                        // Result[i, j] = (dynamic)firstMatrix[i, j] + secondMatrix[i, j];
                        Result[i, j] = AddMatrixHelper<T>.Add(firstMatrix[i, j], secondMatrix[i, j]);
                    }
            }
            catch (InvalidOperationException ex)
            {
                throw new NotSupportedException($"Add of two matrix for {typeof(T)} not suported", ex);

            }
        }
    }

    public static class AddMatrixHelper<T>
    {

        private static readonly Func<T, T, T> matrixAdd;

        static AddMatrixHelper()
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), "lhs");
            ParameterExpression paramB = Expression.Parameter(typeof(T), "rhs");

            BinaryExpression body = Expression.Add(paramA, paramB);
            matrixAdd = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
        }

        public static T Add(T lhs, T rhs) => matrixAdd(lhs, rhs);
    }
}
