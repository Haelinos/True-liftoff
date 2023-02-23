using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
    public class Level : GameObject
    {
        const int WIDTH = 1;
        const int HEIGHT = 1;
        const int SIZE = 1;

        int[,] level = new int[HEIGHT, WIDTH] {

        {1},

        };

        public Level()
        {
            SetupLevel();
        }

        void SetupLevel()
        {
            //initialize game

            for (int row = 0; row < HEIGHT; row++)
            {
                for (int col = 0; col < WIDTH; col++)
                {
                    int tile = level[row, col];

                    switch (tile)
                    {
                        case 1:
                            Menu menu = new Menu();
                            AddChild(menu);
                            menu.x = col * SIZE;
                            menu.y = row * SIZE;
                            break;

                    }
                }
            }
        }
    }
}
