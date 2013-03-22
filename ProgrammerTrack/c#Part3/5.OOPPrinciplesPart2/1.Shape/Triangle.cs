using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shape
{
    class Triangle : Shape
    {
        public override double CalculateSurface()
        {
            return this.height * this.width / 2;
        }

        public Triangle(double width, double height)
        {
            this.height = height;
            this.width = width;
        }
    }
}
