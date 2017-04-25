using System;
using System.Collections.Generic;
using System.Linq;
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
        public static IEnumerable<int> GetFibonacciSequence(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException(nameof(amount));
            int current = 1, previous = 0;

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
