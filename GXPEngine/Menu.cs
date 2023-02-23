using GXPEngine.GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    class Menu : GameObject
    {
        Sprite button;
        Sprite menuBackground;
        Sprite menuDisk;
        Sprite beatdownLogo;

        bool hasStarted;
        public Menu() : base()
        {
            hasStarted= false;

            menuBackground = new Sprite("sprites\\checkered_background.png");
            menuBackground.scale = 0.8f;
            AddChild(menuBackground);
            menuBackground.x = (game.width - menuBackground.width) / 2;
            menuBackground.y = (game.height - menuBackground.height) / 2;

            menuDisk = new Sprite("sprites\\disc.png");
            AddChild(menuDisk);
            menuDisk.SetOrigin(menuDisk.width /2, menuDisk.height /2);
            menuDisk.scale = 2f;
            menuDisk.x = (game.width) / 2 ;
            menuDisk.y = (game.height) / 2 + 800 ;

            button = new Sprite("sprites\\start_button.png");
            AddChild(button);
            button.scale = 0.8f;
            button.x = (game.width - button.width) / 2;
            button.y = (game.height - button.height) / 2 + 300;

            beatdownLogo = new Sprite("sprites\\beatdown.png");
            AddChild(beatdownLogo);
            beatdownLogo.scale = 0.3f;
            beatdownLogo.x = (game.width - beatdownLogo.width) / 2;
            beatdownLogo.y = (game.height - beatdownLogo.height) / 2  - 200;


        }

        void Update() 
        {
            menuDisk.rotation++;

            if (Input.GetKey(Key.R)) 
            {
                StartGame();
                HideMenu();
            }
        
        }

        void HideMenu() 
        {
            menuBackground.visible = false;
            menuDisk.visible = false;
            button.visible = false;
            beatdownLogo.visible = false;
        }

        void StartGame() 
        {
            if (hasStarted == false)
            {
                Level level = new Level();
                AddChild(level);
                hasStarted = true;
            }
            EventSystem.instance.StartLevel();
        }
    }
}
