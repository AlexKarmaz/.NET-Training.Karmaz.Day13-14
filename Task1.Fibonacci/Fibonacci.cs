using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Fibonacci
{
    /// <summary>
    /// Contains a method for calculating Fibonacci numbers
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>Contains the numbers of the Fibonacci sequence</summary>
        /// <param name="amount">Amount of the  Fibonacci's sequence numbers</param>
        /// <returns>IEnumerable{T} which contains the Fibonacci sequence</returns>
        public static IEnumerable<BigInteger> GetFibonacciSequence(BigInteger amount)
        {
            if (amount <= 0)
                throw new ArgumentException(nameof(amount));

           return GetFibonacci(amount);
        }

        private static IEnumerable<BigInteger> GetFibonacci(BigInteger amount)
        {
            BigInteger current = 1, previous = 0;

            yield return 0;

            for (int i = 1; i < amount; i++)
            {
                yield return current;
                current += previous;
                previous = current - previous;
            }
        }
    }
}
