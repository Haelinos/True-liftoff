
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
        private int startPosition;

        private float targetY = 0f;

        public Note(int startPosition, int pitch, int duration, float speed)
        {
            this.startPosition = startPosition;
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
            InitializeNote(duration, c);
        }

        private void InitializeNote(int duration, Color color)
        {
            Sprite top = new Sprite("sprites\\noteUp.png");
            Sprite middle = new Sprite("sprites\\noteMiddle.png");
            Sprite bottom = new Sprite("sprites\\noteBottom.png");

            top.SetOrigin(top.width / 2, top.height);
            middle.SetOrigin(middle.width/2, middle.height);
            bottom.SetOrigin(bottom.width / 2, bottom.height);

            top.SetColor((float)color.R / 255, (float)color.G / 255, (float)color.B / 255);
            middle.SetColor((float)color.R / 255, (float)color.G / 255, (float)color.B / 255);
            bottom.SetColor((float)color.R/255, (float)color.G/255, (float)color.B/255);

            this.x = 400 + 300 * pitch; //Use Constants!

            int noteLength = duration * Constants.PixelsPerLine;// 1f / 20 * (length - 40);

            top.y = -noteLength / 2;
            bottom.y = noteLength / 2;

            //middle.SetScaleXY(1, middleScale);
            //middle.Move(0, -20);
            //up.Move(0, -20 - middle.height);
            //if (length > 40)
            //{
            //}
            AddChild(top);
            AddChild(middle);
            AddChild(bottom);
        }

        public void Step(int songPosition, float speed)
        {
            int currentPosition = songPosition - startPosition;
            targetY = currentPosition * Constants.PixelsPerLine;
//            MoveNoteDown();
        }

        void Update()
        {
            y = y * 0.99f + targetY * 0.01f;
        }

        private void MoveNoteDown()
        {
            y += speed * Constants.PixelsPerLine;
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