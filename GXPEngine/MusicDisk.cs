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
        private float speed;
        private int[] rotations = { 0, 120, 240 };
        string test = "";
        int angle = 0;
        private int detectionTreshold = 60;
        public int rotationIndex = 0;
        public static MusicDisk instance;
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
            instance = this;
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
            if (Input.GetKey(Key.A))
            {
                rotation--;
            }
            else if (Input.GetKey(Key.D))
            {
                rotation++;
            }
            
		}
        public int GetRotationIndex(int offset)
        {
            Console.WriteLine("rotation = " + rotation);
            int trueRotation = (int)(rotation - (int)rotation / 120 * 360);
			foreach (var rot in rotations)
			{
                int offsetRot = rot + offset;
				if (Math.Abs(offsetRot - trueRotation) < detectionTreshold)
				{
					rotationIndex = offsetRot / 120 + 1;
					break;
				}
				else
				{
					rotationIndex = 0;
				}
			}
            Console.WriteLine("rotationIndex = " + rotationIndex);
            return rotationIndex;
		}

    }
}

