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
        public int mainScore;
        private float speed;
        public static Score instance;
        public Score()
        {
            mainScore = 0;
            instance = this;
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

