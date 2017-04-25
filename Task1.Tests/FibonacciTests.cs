using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task1.Fibonacci.Fibonacci;

namespace Task1.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        
        [TestCase(1, ExpectedResult = new int[] {0})]
        [TestCase(2, ExpectedResult = new int[] { 0, 1})]
        [TestCase(3, ExpectedResult = new int[] { 0, 1, 1})]
        [TestCase(11, ExpectedResult = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55})]
        [TestCase(22, ExpectedResult = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946})]
        public IEnumerable<int>  GetFibonacciSequence_PositiveTest(int amount)
        {
           return GetFibonacciSequence(amount);
        }

        //[TestCase(-1)]
        //public void GetFibonacciSequence_ThrowsArgumentException(int amount)
        //{
        //    Assert.Throws<ArgumentException>(() => GetFibonacciSequence(amount));
        //}
    }
}
