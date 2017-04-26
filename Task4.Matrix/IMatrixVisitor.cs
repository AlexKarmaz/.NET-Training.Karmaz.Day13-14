using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public interface IMatrixVisitor<T>
    {
        void Visit(SquareMatrix<T> matrix, Matrix<T> addMatrix);
        void Visit(SymmetricMatrix<T> matrix, Matrix<T> addMatrix);
        void Visit(DiagonalMatrix<T> matrix, Matrix<T> addMatrix);
    }
}
