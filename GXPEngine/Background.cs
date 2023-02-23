using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    class Background : AnimationSprite
    {
        public Background() : base("sprites\\stage.png", 5, 6)
        {
            SetCycle(0, 30);



        }

        void Update() 
        {
            Animate(0.3f);
        }
    }
}
