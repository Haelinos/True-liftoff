
using GXPEngine.GXPEngine;
using GXPEngine.Managers;
using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Note : GameObject
    {
        public MusicDisk musicDisk;
        private int pitch;
        private float speed;

        public Note(float length, int pitch, float speed)
        {
            //SetXY(600, -200);
            EventSystem.instance.onUpdate += Update;
            this.pitch = pitch;
            this.speed = speed;
            Color c = Color.White;
            switch (pitch)
            {
                case 0:
                    c = Color.CadetBlue;
                    break;
                case 1:
                    c = Color.LawnGreen;
                    break;
                case 2:
                    c = Color.Orange;
                    break;
                default:
                    break;
            }
            InitializeNote(length, c);
        }
        private void InitializeNote(float length, Color color)
        {
            Sprite bottom = new Sprite("sprites\\noteBottom.png");
            Sprite middle = new Sprite("sprites\\noteMiddle.png");
            Sprite up = new Sprite("sprites\\noteUp.png");
            bottom.SetOrigin(bottom.width/2, bottom.height);
            middle.SetOrigin(middle.width/2, middle.height);
            up.SetOrigin(up.width/2, up.height);
            bottom.SetColor((float)color.R/255, (float)color.G/255, (float)color.B/255);
            middle.SetColor((float)color.R/255, (float)color.G/255, (float)color.B/255);
            up.SetColor((float)color.R/255, (float)color.G/255, (float)color.B/255);

            float x = 400 + 300 * pitch;
            bottom.SetXY(x, 0);
            middle.SetXY(x, 0);
            up.SetXY(x, 0);
            float middleScale = 1f / 20 * (length - 40);
            middle.SetScaleXY(1, middleScale);
            middle.Move(0, -20);
            up.Move(0, -20 - middle.height);
            if (length > 40)
            {
                AddChild(middle);
            }
            AddChild(up); 
            AddChild(bottom);
        }

        public void Update()
        {
            MoveNoteDown();
        }

        private void MoveNoteDown()
        {
            y += speed;
        }

        void CollisionChecker()
        {
            if (DistanceTo(musicDisk) < musicDisk.width / 2)
            {
                LateDestroy();
            }
        }
    }
}