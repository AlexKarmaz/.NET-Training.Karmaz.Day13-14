using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    public class Triangle : Figure
    {
        public double SideFirst { get; }
        public double SideSecond { get; }
        public double SideThird { get; }

        public Triangle()
        {
            this.SideFirst = 0;
            this.SideSecond = 0;
            this.SideThird = 0;
        }

        public Triangle(double first, double second, double third)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null) || ReferenceEquals(third, null))
                throw new ArgumentNullException();

            this.SideFirst = first;
            this.SideSecond = second;
            this.SideThird = third;
        }

    }
}
