using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
   public class MatrixEventArgs : EventArgs
    {
        public int I { get; }
        public int J { get; }

        public MatrixEventArgs(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}
