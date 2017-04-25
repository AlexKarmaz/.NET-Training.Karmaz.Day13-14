using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.GenericSet;

namespace Task2.Tests
{
    [TestFixture]
    public class SetTests
    {
        private Set<Point> firstSet = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(5, 5) });
        private Set<Point> firstSetCopy = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(5, 5) });
        private Set<Point> secondEmptySet = new Set<Point>();

        [TestCase(ExpectedResult = true)]
        public bool Contains_PositiveTest()
        {
            var newPoint = new Point(1, 1);
            return firstSet.Contains(newPoint);
        }

        [TestCase(ExpectedResult = false)]
        public bool Add_AddExistingElementToSet_PositiveTest()
        {
            var newPoint = new Point(5, 5);
            return firstSet.Add(newPoint);
        }

        [TestCase(ExpectedResult = true)]
        public bool Add_AddElementToSet_PositiveTest()
        {
            var newPoint = new Point(6, 6);
            return firstSet.Add(newPoint);
        }

        [TestCase(ExpectedResult = false)]
        public bool Remove_RemoveExistingElementToSet_PositiveTest()
        {
            var newPoint = new Point(1, 1);
            return firstSet.Add(newPoint);
        }

        [TestCase(ExpectedResult = true)]
        public bool Clear_PositiveTest()
        {
            firstSetCopy.Clear();
            return firstSetCopy.Count == 0;
        }

        [Test]
        public void Add_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => firstSet.Add(null));
        }

    }
}
