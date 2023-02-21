using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Policy;
using GXPEngine.GXPEngine;
using System.IO.Ports;

namespace GXPEngine
{
    public class MusicDisk : AnimationSprite
    {
        SerialPort port = new SerialPort();
        public Note note;
        private float speed;
        string test = "";
		int angle = 0;

        const int angleYellowBegin = 121;
        const int angleYellowEnd = 240;

        const int anglePurpleBegin = 120;
        const int anglePurpleEnd = 1;

        const int angleCyanBegin = 359;
        const int angleCyanEnd = 241;
        const int rotated = 0;
		public MusicDisk(float speed) : base("sprites\\disc.png", 1, 1)
        {
            //port.PortName = "COM5";
            //port.BaudRate = 9600;
            //port.RtsEnable = true;
            //port.DtrEnable = true;
            //port.Open();
            //port.NewLine = "\n";

            this.speed = speed;
            SetOrigin(width / 2, height / 2);
            //scale = 0.6f;
            SetCycle(0, 1);
            EventSystem.instance.onUpdate += Update;



        }

        private void Update()
        {
            //string x = port.ReadExisting();
            //x = x.Split('\n').Last();
            //Console.WriteLine(x);
            //if (x == ""||x=="-")
            //{
            //    return;
            //}
            //int.TryParse(x, out angle);
            //rotation = angle*7.5f;

            Move();

        }

        private void Move() 
        {
            if (Input.GetKey(Key.A))
            {
                rotation--;
                rotated--;
            }
            if (Input.GetKey(Key.D)) 
            {
                rotation++;
                rotated++;
            }
            Console.WriteLine(rotated);
        }

        void CollisionChecker()
        {
            if (rotated is angleYellowBegin) 
            { 
            
            }
            //if (DistanceTo())
            //{
            //}
        }

    }
}

// use rotate and degrees to make a 'distance to' and create a box where the note has to hit in the degrees
// if the notes hit the certain degree, make score system with it
