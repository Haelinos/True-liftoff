using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    class HUDEnd : Canvas
    {
        public HUDEnd() : base(1366, 768, false)
        {

        }
        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString("Player 1 Score :  " + Score.instance.mainScore , Utils.LoadFont("ttf\\Gemstone.ttf",40), Brushes.Yellow, game.width/2, 400);

        }

    }
}
