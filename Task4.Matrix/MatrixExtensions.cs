using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public static class MatrixExtensions
    {
        public static Matrix<T> Add<T>(this Matrix<T> matrix, Matrix<T> addMatrix)
        {
            var visitor = new MatrixSumVisitor<T>();
            matrix.Accept(visitor, addMatrix);
            return visitor.Result;
        }
    }
}
