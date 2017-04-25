using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    public interface IFigureVisitor
    {
        void Visit(Circle circle);
        void Visit(Square square);
        void Visit(Rectangle rectangle);
        void Visit(Triangle rectangle);
    }
}
