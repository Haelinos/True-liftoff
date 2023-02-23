
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
    public class Note : Sprite
    {
        private int pitch;
        private float speed;
        float tempX;
        public Color noteColor;
        int colorIndex;
        private float length = 0;
        private long noteEnd;

        public Note(int pitch, float speed, long noteEnd, int colorIndex) : base("sprites\\note.png")
        {
            //SetXY(600, -200);
            this.pitch = pitch;
            this.speed = speed;
            this.noteEnd = noteEnd;
            this.colorIndex = colorIndex;
            noteColor = Color.White;
            switch (colorIndex)
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
		    SetColor((float)noteColor.R / 255, (float)noteColor.G / 255, (float)noteColor.B / 255);
			x = 350 + 300 * pitch;
			//SetXY(x, 0);
			EventSystem.instance.onUpdate += NoteUpdate;
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
        private void MoveNoteDown()
        {
            y += speed;
            length += speed;
        }

        void CollisionChecker() 
        {
            bool collidedWithDisc = false;
            if (pitch == 1)
            {
				collidedWithDisc = y > 500;
			}
            else
            {
                collidedWithDisc = y > 620;

            }
			bool rightColor = MusicDisk.instance.GetRotationIndex(pitch, colorIndex);
            if (collidedWithDisc && rightColor)
            {
                Score.instance.mainScore++;
                Destroy();
                EventSystem.instance.onUpdate -= NoteUpdate;
            }
        }
    }
}