using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    public class Square : Figure
    {
        public double Side { get; set; }

        public Square() { this.Side = 0; }
        public Square(double side)
        {
            if (ReferenceEquals(side, null))
                throw new ArgumentNullException(nameof(side));

            this.Side = side;
        }
    }
}
