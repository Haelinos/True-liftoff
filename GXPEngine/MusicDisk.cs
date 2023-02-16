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
    class MusicDisk : AnimationSprite
    {
        public MusicDisk() : base("musicdisk.png", 1, 1) 
        {
            SetOrigin(width / 2, this.height / 2);
            scale = 1;
            SetCycle(0, 1);

        }




    //     public void update()
    //    {
    //        turntable();
    //       // collisionchecker();
    //    }
    //    public void turntable()
    //    {
    //        turntable = new easydraw(500, 250);
    //        addchild(turntable);
    //        turntable.setorigin(turntable.width / 2, turntable.height / 2);
    //        turntable.clear(250, 0, 0, 255);
    //        turntable.setxy(920, 1000);
    //    }
    }
}

