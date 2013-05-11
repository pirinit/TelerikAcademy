using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tetris.ShapesStore;

namespace Tetris
{
    static class ShapeFactory
    {
        static private Random random = new Random();

        static public Shape CreateRandomShape(int posRow, int posCol, int blockSize)
        {
            return CreateShape(((Shapes)random.Next(0, 7)), posRow, posCol, blockSize);
        }

        static public Shape CreateShape(Shapes type, int posRow, int posCol, int blockSize)
        {
            switch (type)
            {
                case Shapes.T:
                    return new ShapeT(posRow, posCol, blockSize);
                case Shapes.O:
                    return new ShapeO(posRow, posCol, blockSize);
                case Shapes.J:
                    return new ShapeJ(posRow, posCol, blockSize);
                case Shapes.L:
                    return new ShapeL(posRow, posCol, blockSize);
                case Shapes.I:
                    return new ShapeI(posRow, posCol, blockSize);
                case Shapes.S:
                    return new ShapeS(posRow, posCol, blockSize);
                case Shapes.Z:
                    return new ShapeZ(posRow, posCol, blockSize);
            }
            return new ShapeT(posRow, posCol, blockSize);
        }
    }
}