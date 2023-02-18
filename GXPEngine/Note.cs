
using GXPEngine.GXPEngine;
using GXPEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Note : Sprite
    {
        float speed = 2.5f;
        public MusicDisk musicDisk;

        //---------------------------------------------------------------------------------------------------------------------------
        //                                                      Note()
        //---------------------------------------------------------------------------------------------------------------------------
        public Note(MusicDisk musicDisk) : base("sprites\\circle_blue.png")
        {
            SetOrigin(width / 2, height / 2);
            SetXY(600, -200);
            EventSystem.instance.onUpdate += Update;
            this.musicDisk = musicDisk;
        }


        //---------------------------------------------------------------------------------------------------------------------------
        //                                                      Update()
        //---------------------------------------------------------------------------------------------------------------------------
        public void Update()
        {

            MoveNoteDown();
            CollisionChecker();
        }

        //---------------------------------------------------------------------------------------------------------------------------
        //                                                      MoveNoteDown()
        //---------------------------------------------------------------------------------------------------------------------------
        private void MoveNoteDown()
        {
            x = 600;
            y += speed;
        }

        //---------------------------------------------------------------------------------------------------------------------------
        //                                                      CollisionChecker()
        //---------------------------------------------------------------------------------------------------------------------------

        void CollisionChecker()
        {
            if (DistanceTo(musicDisk) < musicDisk.width / 2)
            {
                LateDestroy();
            }
        }
    }
}