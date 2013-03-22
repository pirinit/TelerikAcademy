using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shape
{
    abstract class Shape
    {
        protected double width;
        protected double height;

        abstract public double CalculateSurface();
    }
}