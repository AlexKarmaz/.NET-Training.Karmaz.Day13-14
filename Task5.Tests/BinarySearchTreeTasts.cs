using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.BinaryTree;
using static System.Math;

namespace Task5.Tests
{
    [TestFixture]
    public class BinarySearchTreeTasts
    {
        [TestCase( ExpectedResult = new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10 })]
        public int[] Inorder_Int32_PositiveTest()
        {
            var tree = new BinarySearchTree<int>(new int[] { 7, 2, 5, 4, 6, 1, 9, 8, 10 });
            return tree.Inorder().ToArray();
        }

        [TestCase( ExpectedResult = new int[] { 7, 5, 4, 2, 1, 6, 9, 8, 10 })]
        public int[] Preorder_Int32_PositiveTest()
        {
            var tree = new BinarySearchTree<int>() { 7, 5, 4, 6, 2, 1, 9, 8, 10 };
            return tree.Preorder().ToArray();
        }

        [TestCase( ExpectedResult = new int[] { 1, 2, 4, 6, 5, 8, 10, 9, 7 })]
        public int[] Postorder_Int32_PositiveTest()
        {
            var tree = new BinarySearchTree<int>() { 7, 5, 4, 6, 2, 1, 9, 8, 10 };
            return tree.Postorder().ToArray();
        }

        [TestCase(3, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public int[] Add_Int32_PositiveTest(int value)
        {
            var tree = new BinarySearchTree<int>() { 7, 5, 4, 6, 2, 1, 9, 8, 10 };
            tree.Add(value);
            return tree.Inorder().ToArray();
        }

        [TestCase(11, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = true)]
        public bool Contains_Int32_PositiveTest(int value)
        {
            var tree = new BinarySearchTree<int>() { 7, 5, 4, 6, 2, 1, 9, 8, 10 };
            return tree.Contains(value);
        }

        [TestCase(ExpectedResult = 10)]
        public int MaxValue_Int32Default()
        {
            var tree = new BinarySearchTree<int>() { 7, 5, 4, 6, 2, 1, 9, 8, 10 };
            return tree.MaxValue();
        }

        [TestCase(ExpectedResult = 99)]
        public int MaxValue_Int32UserComparer()
        {
            var tree = new BinarySearchTree<int>(new int[]{ 7, 5, 4, 6, 2, 1, 99, 8, 10 }, new Int32Comparer());
            return tree.MaxValue();
        }

        [TestCase(ExpectedResult = "xzy")]
        public string MaxValue_StringDefault()
        {
            var tree = new BinarySearchTree<string>() { "aaaa", "abcd", "wwwwww", "xzy"};
            return tree.MaxValue();
        }

        [TestCase(ExpectedResult = "wwwwww")]
        public string MaxValue_StringUserComparer()
        {
            var tree = new BinarySearchTree<string>(new string[] { "aa", "abcd", "wwwwww", "xzy" }, new StringComparer());
            return tree.MaxValue();
        }

        [Test]
        public void MaxValue_BookDefault()
        {
            var tree = new BinarySearchTree<Book>() { new Book("J. K. Rowling", "Harry Potter and the Prisoner of Azkaban", 528, 18.4), new Book("Stephen King", "The Green Mile", 384, 10.6), new Book("Антуан де Сент-Экзюпери", "Маленький принц", 104, 16.7) };
            var result = new Book("Антуан де Сент-Экзюпери", "Маленький принц", 104, 16.7);
            Assert.AreEqual(tree.MaxValue(), result);
        }

        [Test]
        public void MaxValue_BookUserComparer()
        {
            var tree = new BinarySearchTree<Book>(new Book[]{ new Book("J. K. Rowling", "Harry Potter and the Prisoner of Azkaban", 528, 18.4), new Book("Stephen King", "The Green Mile", 384, 10.6), new Book("Антуан де Сент-Экзюпери", "Маленький принц", 104, 16.7) }, new BookComparer());
            var result = new Book("J. K. Rowling", "Harry Potter and the Prisoner of Azkaban", 528, 18.4);
            Assert.AreEqual(tree.MaxValue(), result);
        }

        [Test]
        public void MaxValue_Point2DUserComparer()
        {
            var tree = new BinarySearchTree<Point2D>(new Point2D[] { new Point2D(10, 10), new Point2D(1, 8), new Point2D(5, 20), new Point2D(8, 20) }, new Point2DComparer());
            var result = new Point2D(10,10);
            Assert.AreEqual(tree.MaxValue(), result);
        }

    }

    public class Int32Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                throw new ArgumentNullException();

           return Abs(x).ToString().Length.CompareTo(Abs(y).ToString().Length);
        }
    }

    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                throw new ArgumentNullException();

            return x.Length.CompareTo(y.Length);
        }
    }

    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                throw new ArgumentNullException();

            return(x.Price.CompareTo(y.Price));
        }
    }

    public class Point2DComparer : IComparer<Point2D>
    {
        public int Compare(Point2D x, Point2D y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                throw new ArgumentNullException();

            return (x.X.CompareTo(y.X));
        }
    }
}
