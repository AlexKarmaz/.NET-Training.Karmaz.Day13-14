using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    public static class FigureExtensions
    {
        public static double GetArea(this Figure figure)
        {
            if (ReferenceEquals(figure, null))
                throw new ArgumentNullException(nameof(figure));

            var visitor = new CalculateAreaVisitor();
            figure.Accept(visitor);
            return visitor.Area;
        }

        public static double GetPerimeter(this Figure figure)
        {
            if (ReferenceEquals(figure, null))
                throw new ArgumentNullException(nameof(figure));

            var visitor = new CalculatePerimeterVisitor();
            figure.Accept(visitor);
            return visitor.Perimeter;
        }
    }
}
