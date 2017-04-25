using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    public class Circle : Figure
    {
        public double Radius { get;}

        public Circle() { this.Radius = 0; }
        public Circle(double radius)
        {
            if (ReferenceEquals(radius, null))
                throw new ArgumentNullException(nameof(radius));

            this.Radius = radius;
        }
    }
}
