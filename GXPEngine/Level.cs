using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
//    class Level : GameObject
//    {

//        private MusicDisk musicDisk;


//        //---------------------------------------------------------------------------------------------------------------------------
//        //                                                      Level()
//        //---------------------------------------------------------------------------------------------------------------------------
//        public Level(MusicDisk musicDisk)
//        {
//            this.musicDisk = musicDisk;
//            SetupLevel();
//            Console.WriteLine("ppmaster");
//        }


//        //---------------------------------------------------------------------------------------------------------------------------
//        //                                                      Update()
//        //---------------------------------------------------------------------------------------------------------------------------
//        void Update()
//        {
//        }

//        const int WIDTH = 3;
//        const int HEIGHT = 4;
//        const int SIZE = 500;
//        const int SIZEy = 300;

//        //level 1
//        int[,] level = new int[HEIGHT, WIDTH] {

//        {1, 1, 1},
//        {0, 0, 0},
//        {0, 0, 0},
//        {0, 0, 0},

//        };

//        //---------------------------------------------------------------------------------------------------------------------------
//        //                                                      SetupLevel()
//        //---------------------------------------------------------------------------------------------------------------------------
//        void SetupLevel()
//        {
//            //initialize game

//            for (int row = 0; row < HEIGHT; row++)
//            {
//                for (int col = 0; col < WIDTH; col++)
//                {
//                    int tile = level[row, col];

//                    switch (tile)
//                    {
//                        case 1:
//                            Note note = new Note(musicDisk);
//                            Console.WriteLine(parent);
//                            AddChild(note);
//                            note.x = col * SIZE + 425;
//                            note.y = row * SIZEy;
//                            Console.WriteLine("poep");
//                            break;
//                    }
//                }
//            }
//        }
//    }
}
