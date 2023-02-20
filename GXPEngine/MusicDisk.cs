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
        string test = "";
		int angle = 0;
		public MusicDisk(float speed) : base("sprites\\disc.png", 1, 1)
        {
			port.PortName = "COM5";
			port.BaudRate = 9600;
			port.RtsEnable = true;
			port.DtrEnable = true;
			port.Open();
            port.NewLine= "\n";
			this.speed = speed;
            SetOrigin(width / 2, height / 2);
            scale = 0.6f;
            SetCycle(0, 1);
            EventSystem.instance.onUpdate += Update;
        }
        private void Update()
        {
            string x = port.ReadExisting();
            x = x.Split('\n').Last();
            //Console.WriteLine(x);
            if (x == ""||x=="-")
            {
                return;
            }
            int.TryParse(x, out angle);
            rotation = angle*7.5f;
		}
    }
}

