using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine.GXPEngine
{
    internal class EndScreen : AnimationSprite
    {
        Sprite menuDisk;
        Sprite beatdownLogo;
        HUDEnd hudEnd;
        public EndScreen() : base("sprites\\checkered_background.png", 1, 1)
        {
            menuDisk = new Sprite("sprites\\disc.png");
            AddChild(menuDisk);
            menuDisk.SetOrigin(menuDisk.width / 2, menuDisk.height / 2);
            menuDisk.scale = 1.5f;
            menuDisk.x = (game.width) / 2 - 800;
            menuDisk.y = (game.height) / 2;

            beatdownLogo = new Sprite("sprites\\beatdown.png");
            AddChild(beatdownLogo);
            beatdownLogo.scale = 0.2f;
            beatdownLogo.x = (game.width - beatdownLogo.width) / 2 + 200;
            beatdownLogo.y = (game.height - beatdownLogo.height) / 2 - 250;

            hudEnd = new HUDEnd();
            AddChild(hudEnd);


        }

        void Update()
        {
            menuDisk.rotation++;
            
        }
    }
}
