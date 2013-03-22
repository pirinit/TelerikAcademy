using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Bullet : Ball
    {
        public Bullet(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {

        }
    }
}
