using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Figures
{
    public abstract class Figure
    {
        public void Accept(IFigureVisitor visitor)
        {
            if (ReferenceEquals(visitor, null))
                throw new ArgumentNullException(nameof(visitor));

            visitor.Visit((dynamic)this);
        }
    }
}
