
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
        private int pitch;
        private float speed;

        public Color noteColor;
        private float length = 0;
        private long noteEnd;

        public Note(int pitch, float speed, long noteEnd)
        {
            //SetXY(600, -200);
            
            this.pitch = pitch;
            this.speed = speed;
            this.noteEnd = noteEnd;
            noteColor = Color.White;
            switch (pitch)
            {
                case 0:
                    noteColor = Color.CadetBlue;
                    break;
                case 1:
                    noteColor = Color.LawnGreen;
                    break;
                case 2:
                    noteColor = Color.Orange;
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
			bottom.SetXY(x, 0);
            AddChild(bottom);
			EventSystem.instance.onUpdate += NoteUpdate;
			EventSystem.instance.onUpdate += CheckForEnd;
		}
        private void InitializeNoteEnd()
        {
			Sprite middle = new Sprite("sprites\\noteMiddle.png");
			Sprite up = new Sprite("sprites\\noteUp.png");

			middle.SetOrigin(middle.width / 2, middle.height);
			up.SetOrigin(up.width / 2, up.height);

            middle.SetColor((float)noteColor.R / 255, (float)noteColor.G / 255, (float)noteColor.B / 255);
            up.SetColor((float)noteColor.R / 255, (float)noteColor.G / 255, (float)noteColor.B / 255);

            float x = 400 + 300 * pitch;

            middle.SetXY(x, 0);
            up.SetXY(x, 0);

            float middleScale = 1f / 20 * (length - 20);

            middle.SetScaleXY(1, middleScale);
            middle.Move(0, -20);

            up.Move(0, -20 - middle.height);

            if (length > 40)
            {
            }
            AddChild(middle);
            AddChild(up);
        }
		public void NoteUpdate()
        {
            MoveNoteDown();
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
    }
}