using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Figures;

namespace Task3.Tests
{
    [TestFixture]
    public class FiguresTests
    {
        public static IEnumerable<TestCaseData> TestAreaDatas
        {
            get
            {
                yield return new TestCaseData(new Circle(), 0);
                yield return new TestCaseData(new Rectangle(5, 10), 50);
                yield return new TestCaseData(new Triangle(3, 4 , 5), 6);
                yield return new TestCaseData(new Square(2), 4);
                yield return new TestCaseData(new Square(), 0);
            }
        }

        public static IEnumerable<TestCaseData> TestPerimeterDatas
        {
            get
            {
                yield return new TestCaseData(new Circle(), 0);
                yield return new TestCaseData(new Rectangle(5, 10), 30);
                yield return new TestCaseData(new Triangle(3, 4, 5), 12);
                yield return new TestCaseData(new Square(2),8);
                yield return new TestCaseData(new Square(), 0);
            }
        }

        [Test, TestCaseSource(nameof(TestAreaDatas))]
        public void GetArea_PositiveTest(Figure figure, double result)
        {
            double area = figure.GetArea();
            Assert.AreEqual(area, result);
        }

        [Test, TestCaseSource(nameof(TestPerimeterDatas))]
        public void GetPerimeter_PositiveTest(Figure figure, double result)
        {
            double perimeter = figure.GetPerimeter();
            Assert.AreEqual(perimeter, result);
        }

        [Test]
        [TestCase(null)]
        public void GetPerimeter_ThrowsArgumentNullException(Figure figure)
        {
            Assert.Throws<ArgumentNullException>(() => figure.GetPerimeter());
        }
    }
}
