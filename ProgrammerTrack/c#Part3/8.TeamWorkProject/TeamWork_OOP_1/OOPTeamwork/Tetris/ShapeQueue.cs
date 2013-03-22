using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Interfaces;

namespace Tetris
{
    class ShapeQueue : IDrawable
    {
        private List<Shape> shapes = new List<Shape>();

        public ShapeQueue()
        {
            this.shapes = new List<Shape>(4);
            //adding the next 3 shapes in the queue
            for (int i = 0; i < 3; i++)
            {
                Shape current = ShapeFactory.CreateRandomShape(0,6,20);
                shapes.Add(PrepareNextQueueShape(current, Program.ShapeQueueRowOffset, Program.ShapeQueueColOffset));
            }
         
        }

        private Shape PrepareNextQueueShape(Shape shape,int rowOffset, int colOffset)
        {
            foreach (var block in shape.GetBlocks)
            {
                //shifting the offset so the forms display properly outside of the game field
                block.RowOffset = rowOffset;
                block.ColOffset = colOffset;
            }
            return shape;
        }

        private void MoveQueueShapesDown()
        {
            foreach (var shape in shapes)
            {
                foreach (var block in shape.GetBlocks)
                {
                    block.RowOffset += Program.BlockSize * 2 + 10;
                }
            }
        }

        public void Draw(System.Drawing.Graphics surface)
        {
            foreach (var shape in this.shapes)
            {
                shape.Draw(surface);
            }
        }

        internal Shape NextShape()
        {
            Shape tempShape = shapes[0];
            shapes.RemoveAt(0);
            Shape current = ShapeFactory.CreateRandomShape(0,6,20);
            MoveQueueShapesDown();
            shapes.Add(PrepareNextQueueShape(current,Program.ShapeQueueRowOffset, Program.ShapeQueueColOffset));
            tempShape = PrepareNextQueueShape(tempShape, Program.GamefieldRowOffset, Program.GamefieldColOffset);
            return tempShape;
        }
    }
}
