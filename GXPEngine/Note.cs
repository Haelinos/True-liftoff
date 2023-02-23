
using GXPEngine.GXPEngine;
using GXPEngine.Managers;
using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Note : GameObject
    {
        MusicDisk musicDisk;
        private int pitch;
        private float speed;
        float tempX;
        public Color noteColor;
        private float length = 0;
        private long noteEnd;

        public Note(int pitch, float speed, long noteEnd)
        {
            //SetXY(600, -200);
            musicDisk = new MusicDisk(speed);
            this.pitch = pitch;
            this.speed = speed;
            this.noteEnd = noteEnd;
            noteColor = Color.White;
            switch (pitch)
            {
                case 0:
                    noteColor = Color.Cyan;
                    break;
                case 1:
                    noteColor = Color.Purple;
                    break;
                case 2:
                    noteColor = Color.Yellow;
                    break;
                default:
                    break;
            }
            InitializeNoteStart();
        }

        private void InitializeNoteStart()
        {
            Sprite bottom = new Sprite("sprites\\noteBottom.png");
			bottom.SetOrigin(bottom.width / 2, bottom.height);
			bottom.SetColor((float)noteColor.R / 255, (float)noteColor.G / 255, (float)noteColor.B / 255);
			float x = 400 + 300 * pitch;
            tempX = x;
			bottom.SetXY(x, 0);
            AddChild(bottom);
			EventSystem.instance.onUpdate += NoteUpdate;
			EventSystem.instance.onUpdate += CheckForEnd;
		}
        private void InitializeNoteEnd()
        {
            //middle note does not match up with other 2 parts 
			Sprite middle = new Sprite("sprites\\noteMiddle.png");
			Sprite top = new Sprite("sprites\\noteUp.png");

			middle.SetOrigin(middle.width / 2, middle.height);
			top.SetOrigin(top.width / 2, top.height);

            middle.SetColor((float)noteColor.R / 255, (float)noteColor.G / 255, (float)noteColor.B / 255);
            top.SetColor((float)noteColor.R / 255, (float)noteColor.G / 255, (float)noteColor.B / 255);

            float x = 400 + 300 * pitch;

            middle.SetXY(x, 0);
            top.SetXY(x, 0);

            float middleScale = 1f / 20 * (length - 20);
            Console.WriteLine(length);
            middle.SetScaleXY(1, middleScale);
            middle.Move(0, -20);

            top.Move(0, -20 - middle.height);

            if (length > 40)
            {
            }
            AddChild(middle);
            AddChild(top);
        }
		public void NoteUpdate()
        {
            MoveNoteDown();
            CollisionChecker();
            if (y>1000)
            {
                Destroy();
            }
        }
        private void CheckForEnd()
        {
            if(AudioManager.instance.GetPosition() >= noteEnd)
            {
                EventSystem.instance.onUpdate -= CheckForEnd;
                InitializeNoteEnd();
            }
        }
        private void MoveNoteDown()
        {
            y += speed;
            length += speed;
        }

        void CollisionChecker() 
        {
            //Console.WriteLine(rotation);
            musicDisk.GetRotationIndex(0);
            Mathf.CalculateAngleDeg(musicDisk.width / 2, musicDisk.width / 2, tempX, y);
            //Console.WriteLine(tempX);

            //if (DistanceTo(Mathf.CalculateAngleDeg(musicDisk.width / 2, musicDisk.width / 2, tempX, y) ))
            //{

            //}
            //Console.WriteLine("({0}, {1}) -> ( {2}, {3})", musicDisk.x + musicDisk.width / 2, musicDisk.y +  musicDisk.height / 2, tempX, y);
            //Console.WriteLine(Mathf.CalculateAngleDeg(musicDisk.x + musicDisk.width / 2, musicDisk.y + musicDisk.height / 2, tempX, y));

            ////Console.WriteLine(pitch);
            //if (pitch == 0 && musicDisk.rotationIndex == 0) 
            //{
            //    if () { }
            //}
            //if (pitch == 1 && musicDisk.rotationIndex == 1) 
            //{
            //    if () { }
            //}
            //if (pitch == 2 && musicDisk.rotationIndex == 2)
            //{
            //    if () { }
            //}

            // check for the right colour and check for right position of distanceto and the rotated circle

        }
    }
}