using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Task1.Fibonacci.Fibonacci;

namespace Task1.Tests
{
    [TestFixture]
    public class FibonacciTests
    {

        private static IEnumerable<TestCaseData> TestDatas
        {
            get
            {
                yield return new TestCaseData(1, new BigInteger[] { 0 });
                yield return new TestCaseData(2, new BigInteger[] { 0, 1 });
                yield return new TestCaseData(3, new BigInteger[] { 0, 1, 1 });
                yield return new TestCaseData(11, new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 });
                yield return new TestCaseData(22, new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946 });
            }
                    
        }

        [TestCaseSource(nameof(TestDatas))]
        public void  GetFibonacciSequence_PositiveTest(BigInteger amount, BigInteger[] result)
        {
            Assert.AreEqual((GetFibonacciSequence(amount)), result);
        }

        [TestCase(-1)]
        public void GetFibonacciSequence_ThrowsArgumentException(BigInteger amount)
        {
            Assert.Throws<ArgumentException>(() => GetFibonacciSequence(amount));
        }
    }
}
