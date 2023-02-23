﻿using System;
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
                            Background background = new Background();
                            AddChild(background);
                            background.x = col * SIZE;
                            background.y = row * SIZE;
                            background.SetOrigin(background.width / 2, background.height / 2);
                            background.SetXY(game.width / 2, game.height / 2);

                            MusicDisk musicDisk = new MusicDisk(0.55f);
                            AddChild(musicDisk);
                            musicDisk.SetXY(game.width / 2, game.height / 2 + 500);

                            break;

                    }
                }
            }
        }
    }
}
