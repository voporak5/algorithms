using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Match3
{
    internal class GameManager
    {
        private Grid grid;

        public GameManager(Grid grid)
        {
            this.grid = grid;
        }

        public void Run()
        {
            grid.Display();
        }
    }
}
