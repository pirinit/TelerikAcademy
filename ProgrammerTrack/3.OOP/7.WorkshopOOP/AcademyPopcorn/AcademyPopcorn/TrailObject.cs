using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /* 5. Implement a TrailObject class. It should inherit the GameObject class
     * and should have a constructor which takes an additional "lifetime" integer.
     * The TrailObject should disappear after a "lifetime" amount of turns.
     * You must NOT edit any existing .cs file.
     * */

    class TrailObject : GameObject
    {
        private int lifetime;
        internal TrailObject(MatrixCoords topLeft, int lifetime)
            : base(topLeft, new char[,] { { '.' } })
        {
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            if (lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
            lifetime--;
        }
    }
}
