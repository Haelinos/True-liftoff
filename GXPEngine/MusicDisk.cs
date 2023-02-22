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
using System.Runtime.CompilerServices;

namespace GXPEngine
{
    public class MusicDisk : AnimationSprite
    {
        SerialPort port = new SerialPort();
        List<Note> drawnNotes;
        private float speed;
        string test = "";
		int angle = 0;

        const int angleCyanBegin = 0;
        const int angleCyanEnd = 120;

        const int angleYellowBegin = 120;
        const int angleYellowEnd = 240;

        const int anglePurpleBegin = 240;
        const int anglePurpleEnd = 360;



        int rotated = 0;

		public MusicDisk(float speed, List<Note> drawnNotes) : base("sprites\\disc.png", 1, 1)
        {
            //port.PortName = "COM5";
            //port.BaudRate = 9600;
            //port.RtsEnable = true;
            //port.DtrEnable = true;
            //port.Open();
            //port.NewLine = "\n";

            this.speed = speed;
            this.drawnNotes = drawnNotes;
            SetOrigin(width / 2, height / 2 );
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
            CollisionChecker();
            TrackAngle();

        }

        private void Move() 
        {
            if (Input.GetKey(Key.A))
            {
                rotation--;
            }
            if (Input.GetKey(Key.D)) 
            {
                rotation++;
            }
        }

        void TrackAngle() 
        {


        }

        void CollisionChecker()
        {
            foreach (Note i in drawnNotes)
            {
                if (DistanceTo(i) < this.width / 2)
                {
                    //float distY = y - i.y;
                    //float distX = x - i.x;
                    //float dist = Mathf.Sqrt((distY * distY) + (distX * distX));
                    Console.WriteLine(Mathf.CalculateAngleDeg(x, y, i.x, i.y));
                    //if (CalculateAngleDeg(x, y, i.x, i.y) > angleCyanBegin) 
                    //{ 
                    
                    //}
                    
                }
                //Console.WriteLine("musicDisk: {0} {1} note: {2} {3} DistanceTo : {4}", x, y, i.x, i.y, DistanceTo(i));
                //Console.WriteLine(i.parent);
            }

            // check welke angle het hit
            // check wat rotation is van musicDisk
            // check kleur van note
        }
    }
}

