using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Interfaces;
using System.Drawing;

namespace Tetris
{
    class UserInterface : IDrawable
    {
        Rectangle gridBorders = new Rectangle(
            Program.GamefieldColOffset - 2,
            Program.GamefieldRowOffset - 2,
            Program.BlockSize * GridManager.Width + 4,
            Program.BlockSize * GridManager.Height + 4);

        Pen pen = new Pen(new SolidBrush(Color.Black), 2f);

        public void Draw(System.Drawing.Graphics surface)
        {
            surface.DrawRectangle(this.pen, this.gridBorders);

            
        }
    }
}