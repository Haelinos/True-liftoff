using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    class HUD : Canvas
    {
        public HUD() : base(1366, 768, false)
        {

        }
        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString("Score :  " + Score.instance.mainScore, Utils.LoadFont("ttf\\Gemstone.ttf", 32), Brushes.Yellow, 0, 0);

        }

    }
}
