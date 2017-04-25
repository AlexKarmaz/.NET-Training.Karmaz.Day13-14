using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    public class CalculatePerimeterVisitor : IFigureVisitor
    {
        public double Perimeter { get; private set; }

        public void Visit(Circle circle)
        {
            if (ReferenceEquals(circle, null))
                throw new ArgumentNullException(nameof(circle));

            Perimeter = 2 * Math.PI * circle.Radius;
        }

        public void Visit(Square square)
        {
            if (ReferenceEquals(square, null))
                throw new ArgumentNullException(nameof(square));

            Perimeter = 4 * square.Side;
        }

        public void Visit(Rectangle rectangle)
        {
            if (ReferenceEquals(rectangle, null))
                throw new ArgumentNullException(nameof(rectangle));

            Perimeter = 2 * (rectangle.Width + rectangle.Height);
        }

        public void Visit(Triangle triangle)
        {
            if (ReferenceEquals(triangle, null))
                throw new ArgumentNullException(nameof(triangle));

            Perimeter = triangle.SideFirst + triangle.SideSecond + triangle.SideThird;
        }
    }
}
