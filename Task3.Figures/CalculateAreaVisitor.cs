using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    public class CalculateAreaVisitor : IFigureVisitor
    {
        public double Area { get; private set; }

        public void Visit(Circle circle)
        {
            if (ReferenceEquals(circle, null))
                throw new ArgumentNullException(nameof(circle));

            Area = Math.PI * Math.Pow(circle.Radius, 2);
        }

        public void Visit(Square square)
        {
            if (ReferenceEquals(square, null))
                throw new ArgumentNullException(nameof(square));

            Area = square.Side * square.Side ;
        }

        public void Visit(Rectangle rectangle)
        {
            if (ReferenceEquals(rectangle, null))
                throw new ArgumentNullException(nameof(rectangle));

            Area = rectangle.Width * rectangle.Height;
        }

        public void Visit(Triangle triangle)
        {
            if (ReferenceEquals(triangle, null))
                throw new ArgumentNullException(nameof(triangle));

            double p = (triangle.SideFirst + triangle.SideSecond + triangle.SideThird) / 2;
            Area = Math.Sqrt(p * (p - triangle.SideFirst) * (p - triangle.SideSecond) * (p - triangle.SideThird));
        }
    }
}
