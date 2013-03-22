using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shape
{
    class Circle : Shape
    {
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
                this.height = value;
            }
        }

        public Circle(double radius)
        {
            this.width = radius * 2;
            this.height = radius * 2;
        }
        public override double CalculateSurface()
        {
            double radius = this.width / 2;
            double area = Math.PI * radius * radius;
            return area;
        }
    }
}
