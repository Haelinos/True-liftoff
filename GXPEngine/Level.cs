using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
     class Level : GameObject
    {
        //---------------------------------------------------------------------------------------------------------------------------
        //                                                      Update()
        //---------------------------------------------------------------------------------------------------------------------------
        void Update()
        {

            //if (Controller.GetKeyUp(Key.SPACE))
            //{
            //    for (int i = 0; i < 1; i++)
            //    {
            //        Note note = new Note();
            //        AddChild(note);

            //    }


            //}
        }
    
        const int WIDTH = 3;
        const int HEIGHT = 4;
        const int SIZE = 500;
        const int SIZEy = 300;

        //level 1
        int[,] level = new int[HEIGHT, WIDTH] {

        {2, 2, 2},
        {0, 0, 0},
        {0, 0, 0},
        {1, 1, 1},

        };

        //---------------------------------------------------------------------------------------------------------------------------
        //                                                      Level()
        //---------------------------------------------------------------------------------------------------------------------------
        public Level()
        {
            SetupLevel();
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //                                                      SetupLevel()
        //---------------------------------------------------------------------------------------------------------------------------
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
                            MusicDisk musicDisk = new MusicDisk();
                            AddChild(musicDisk);
                            musicDisk.x = col * SIZE + 425;
                            musicDisk.y = row * SIZEy;
                            break;

                        case 2:
                                Note note = new Note();
                                AddChild(note);
                                note.x = col * SIZE + 425;
                                note.y = row * SIZEy;
                                break;
                                //make notes display random, in a loop? 

                    }
                }
            }
        }
    }
}
