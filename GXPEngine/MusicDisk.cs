using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Policy;

namespace GXPEngine
{
    public class MusicDisk : AnimationSprite
    {
        public MusicDisk() : base("musicdisk.png", 1, 1) 
        {
            SetOrigin(width / 2, height / 2);
            scale = 0.5f;
            SetCycle(0, 1);

        }




        public void Update()
        {
        }
    }
}

