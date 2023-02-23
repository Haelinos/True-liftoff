
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

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //                                                                  Note()
        //____________________________________________________________________________________________________________________________________________
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

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //                                                          InitializeNoteStart()
        //____________________________________________________________________________________________________________________________________________
        private void InitializeNoteStart()
        {
            // add a list with the 3 different colours (png)
            //var bottomSprite = new List<String> { "sprites\\notes\\square_bottom_cyan.png", "sprites\\notes\\square_bottom_yellow.png", "sprites\\notes\\square_bottom_purple.png" };

            Sprite bottom = new Sprite("sprites\\notes\\square_bottom_cyan.png");
			bottom.SetOrigin(bottom.width / 2, bottom.height);
			bottom.SetColor((float)noteColor.R / 255, (float)noteColor.G / 255, (float)noteColor.B / 255);

			float x = 400 + 300 * pitch;
			bottom.SetXY(x, 0);
            AddChild(bottom);
			EventSystem.instance.onUpdate += NoteUpdate;
			EventSystem.instance.onUpdate += CheckForEnd;
		}

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //                                                          InitializeNoteEnd()
        //____________________________________________________________________________________________________________________________________________
        private void InitializeNoteEnd()
        {
			Sprite middle = new Sprite("sprites\\notes\\square_middle_cyan.png");
			middle.SetOrigin(middle.width / 2, middle.height);
            middle.SetColor((float)noteColor.R / 255, (float)noteColor.G / 255, (float)noteColor.B / 255);

            Sprite top = new Sprite("sprites\\notes\\square_top_cyan.png");
            top.SetOrigin(top.width / 2, top.height);
            top.SetColor((float)noteColor.R / 255, (float)noteColor.G / 255, (float)noteColor.B / 255);

            float x = 400 + 300 * pitch;
            middle.SetXY(x, 0);
            top.SetXY(x, 0);

            float middleScale = 1f / 20 * (length - 20);

            middle.SetScaleXY(1, middleScale);
            middle.Move(0, -20);

            top.Move(0, -20 - middle.height);

            if (length > 40)
            {
            }
            AddChild(middle);
            AddChild(top);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //                                                          NoteUpdate()
        //____________________________________________________________________________________________________________________________________________
        public void NoteUpdate()
        {
            MoveNoteDown();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //                                                          CheckForEnd()
        //____________________________________________________________________________________________________________________________________________
        private void CheckForEnd()
        {
            if(AudioManager.instance.GetPosition() >= noteEnd)
            {
                EventSystem.instance.onUpdate -= CheckForEnd;
                InitializeNoteEnd();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //                                                          MoveNoteDown()
        //____________________________________________________________________________________________________________________________________________
        private void MoveNoteDown()
        {
            y += speed;
            length += speed;
        }
    }
}