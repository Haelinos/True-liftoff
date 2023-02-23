using System;
using GXPEngine.GXPEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Instrumentation;

namespace GXPEngine
{
    class Score : GameObject
    {
        int _score;
        private float speed;
        MusicDisk musicDisk;
        public Score()
        {
            _score = 0;
            musicDisk = new MusicDisk(speed);

        }

        public void Update() 
        {
            //Console.WriteLine(_score);
            //Console.WriteLine(musicDisk.rotationIndex);

        }
        //public int IncreaseScore()
        //{
        //    if ()
        //    {
        //        return _score;
        //    }

        //    return 10;
        //}
        // if statement should be a boolean for the whole code in note class

    }
}

