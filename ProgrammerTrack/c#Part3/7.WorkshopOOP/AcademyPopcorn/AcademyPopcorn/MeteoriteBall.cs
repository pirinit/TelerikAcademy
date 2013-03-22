using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /* 6. Implement a MeteoriteBall. It should inherit the Ball class
     * and should leave a trail of TrailObject objects.
     * Each trail objects should last for 3 "turns". Other than that,
     * the Meteorite ball should behave the same way as the normal ball.
     * You must NOT edit any existing .cs file.
     */
    class MeteoriteBall : Ball
    {
        const int TrailLifetime = 3;
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft,speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> result = new List<TrailObject>();
            TrailObject trail = new TrailObject(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), TrailLifetime);
            result.Add(trail);
            return result;
        }
    }
}
