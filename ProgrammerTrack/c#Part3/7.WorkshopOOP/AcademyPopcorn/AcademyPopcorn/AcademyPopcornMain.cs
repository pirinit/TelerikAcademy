using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 4;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                Block currBlock1 = new Block(new MatrixCoords(startRow+1, i));

                engine.AddObject(currBlock);
                engine.AddObject(currBlock1);
            }

            //1.Task - walls and roof

            for (int row = 0; row < WorldRows; row++)
            {
                IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(row, 0));
                IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));

                engine.AddObject(leftWall);
                engine.AddObject(rightWall);
            }

            for (int col = 0; col < WorldCols; col++)
            {
                IndestructibleBlock roof = new IndestructibleBlock(new MatrixCoords(0, col));
                engine.AddObject(roof);
            }

            //8.Task - add unpassable block
            for (int col = 0; col < WorldCols; col++)
            {
                UnpassableBlock block = new UnpassableBlock(new MatrixCoords(2, col));
                engine.AddObject(block);
            }

            //MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));

            UnstopableBall theBall = new UnstopableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}