using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    public class Rectangle : Figure
    {
        public double Width { get;}
        public double Height { get;}
        
        public Rectangle()
        {
            this.Width = 0;
            this.Height = 0;
        }

        public Rectangle(int width, int height)
        {
            if (ReferenceEquals(width, null) || ReferenceEquals(height, null))
                throw new ArgumentNullException();

            this.Width = width;
            this.Height = height;
        }

        
        //double CalculatePerimeter() { return 2*(this.Width + this.Height); }


    }
}
