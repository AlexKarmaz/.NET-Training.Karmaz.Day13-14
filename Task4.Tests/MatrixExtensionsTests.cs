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
    public class MatrixExtensionsTests
    {
        private static IEnumerable<TestCaseData> TestDatas
        {
            get
            {
                yield return new TestCaseData(
                    new SquareMatrix<int>(new[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } }),
                    new DiagonalMatrix<int>(new[,] { { 1, 0, 0 }, { 0, 2, 0 }, { 0, 0, 3 } }),
                    new SquareMatrix<int>(new[,] { { 1, 1, 2 }, { 3, 6, 5 }, { 6, 7, 11 } }));
            }
        }

        [TestCaseSource(nameof(TestDatas))]
        public void Add_PositiveTest(Matrix<int> firstMatrix, Matrix<int> secondMatrix, Matrix<int> resultMatrix)
        {
            SquareMatrix<int> result = firstMatrix.Add(secondMatrix);

            Assert.AreEqual(resultMatrix.Equals(result), true);
        }
    }
}
