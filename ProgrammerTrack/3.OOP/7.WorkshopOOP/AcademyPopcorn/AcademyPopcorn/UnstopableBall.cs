using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstopableBall : Ball
    {
        public new const string CollisionGroupString = "UnstopableBall";

        public UnstopableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft,speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return UnstopableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings[0] == "UnpassableBlock"
                || collisionData.hitObjectsCollisionGroupStrings[0] == "IndestructibleBlock"
                || collisionData.hitObjectsCollisionGroupStrings[0] == "racket")
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                {
                    this.Speed.Row *= -1;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                {
                    this.Speed.Col *= -1;
                }
            }
        }
    }
}
