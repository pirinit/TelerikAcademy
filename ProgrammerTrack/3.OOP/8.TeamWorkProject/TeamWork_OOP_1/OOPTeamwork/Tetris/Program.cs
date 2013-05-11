using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    static class Program
    {
        public const int GamefieldRowOffset = 20;
        public const int GamefieldColOffset = 20;
        public const int ShapeQueueRowOffset = 0;
        public const int ShapeQueueColOffset = -115;
        public const int BlockSize = 20;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TetrisForm());
        }
    }
}
