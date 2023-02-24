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
			rotation = 100000;
		}
        private void Update()
        {

            //string x = port.ReadExisting();
            //x = x.Split('\n').Last();
            //Console.WriteLine(x);
            //if (x == "" || x == "-")
            //{
            //    return;
            //}
            //int.TryParse(x, out angle);
            //Console.WriteLine(angle);
            //rotation = angle * 7.5f;
            if (Input.GetKey(Key.A))
            {
                rotation--;
            }
            else if (Input.GetKey(Key.D))
            {
                rotation++;
            }
            
		}
        public bool GetRotationIndex(int row, int color)
        {
            //0 c
            //1 m
            //2 y
            

            int trueRotation = (int)rotation - (int)(rotation / 360) * 360;

            // this part of code is self aware meta irony written in the night before the presentation
            if (row == 0)
            {
                if (color == 0)
                {
                    if (trueRotation > 195 && trueRotation < 315 )
                    {
                        return true;
                    }
                }
                else if (color == 1)
                {
                    if (trueRotation > 315 || trueRotation < 75)
                    {
                        return true;
                    }
                }
                else if (color == 2)
                {
                    if (trueRotation > 75 && trueRotation < 195)
                    {
                        return true;
                    }
                }
            }
            else if (row == 1)
            {
                if (color == 0)
                {
                    if (trueRotation > 240)
                    {
                        return true;
                    }
                }
                else if (color == 1)
                {
                    if (trueRotation > 0 && trueRotation < 120)
                    {
                        return true;
                    }
                }
                else if (color == 2)
                {
                    if (trueRotation > 120 && trueRotation < 240)
                    {
                        return true;
                    }
                }
            }
            else if (row == 2)
            {
                if (color == 0)
                {
                    if (trueRotation < 45 || trueRotation > 285)
                    {
                        return true;
                    }
                }
                else if (color == 1)
                {
                    if (trueRotation > 45 && trueRotation < 165)
                    {
                        return true;
                    }
                }
                else if (color == 2)
                {
                    if (trueRotation > 165 && trueRotation < 285)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}

