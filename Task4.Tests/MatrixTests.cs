using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Matrix;


namespace Task4.Tests
{
    [TestFixture]
    class MatrixTests
    {
        private static IEnumerable<TestCaseData> TestEqualsDatas
        {
            get
            {
                yield return new TestCaseData(
                    new SquareMatrix<int>(new[,] { { 1, 1, 2 }, { 3, 6, 5 }, { 6, 7, 11 } }),
                    new SquareMatrix<int>(new[,] { { 1, 1, 2 }, { 3, 6, 5 }, { 6, 7, 11 } }),
                    true);
                yield return new TestCaseData(
                   new SymmetricMatrix<int>(new[,] { { 1, 3, }, { 3, 6}}),
                   new SymmetricMatrix<int>(new[,] { { 1, 3, }, { 3, 6}}),
                   true);
                yield return new TestCaseData(
                   new DiagonalMatrix<int>(new[,] { { 1, 0, 0 }, { 0, 6, 0 }, { 0, 0, 11 } }),
                   new DiagonalMatrix<int>(new[,] { { 1, 0, 0 }, { 0, 6, 0 }, { 0, 0, 11 } }),
                   true);
            }
        }
        [TestCaseSource(nameof(TestEqualsDatas))]
        public void Equals_PositiveTest(Matrix<int> firstMatrix, Matrix<int> secondMatrix, bool result)
        {
            Assert.AreEqual(firstMatrix.Equals(secondMatrix), result);
        }

        public static IEnumerable<TestCaseData> GetEnumeratorDatas
        {
            get
            {
                yield return new TestCaseData(new SquareMatrix<int>(new int[,] { { 1, 2 }, { 3, 4 } })).Returns(10);
                yield return new TestCaseData(new SymmetricMatrix<int>(new int[,] { { 1, 2 }, { 2, 4 } })).Returns(9);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[,] { { 1, 0 }, { 0, 4 } })).Returns(5);
            }
        }

        [TestCaseSource("GetEnumeratorDatas")]
        public static int GetEnumerator_PositiveTest(Matrix<int> matrix)
        {
            int i = 0;
            foreach (var item in matrix)
            {
                i+=item;
            }

            return i;
        }
    }

    class MatrixListener
    {
        public bool flag = false;

        public void Register<T>(Matrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            matrix.Update += MatrixUpdate;
        }

        public void Unregister<T>(Matrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            matrix.Update -= MatrixUpdate;
        }

        public void MatrixUpdate(object sender, MatrixEventArgs e)
        {
            flag = !flag;
        }
    }
}
