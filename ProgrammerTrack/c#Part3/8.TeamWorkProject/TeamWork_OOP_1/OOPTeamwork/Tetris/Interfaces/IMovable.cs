using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Interfaces
{
    interface IMovable
    {
        bool MoveDown();
        void MoveLeft();
        void MoveRight();
        bool IsPossibleMoveDown();
        bool IsPossibleMoveLeft();
        bool IsPossibleMoveRight();
    }
}
