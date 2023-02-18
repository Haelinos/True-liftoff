using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class AudioManager
	{
		public static AudioManager instance;
		public SoundChannel channel;
		public AudioManager()
		{
			instance = this;	
		}
		public void StartSong(string path)
		{
			channel = new Sound(path).Play();
		}
		public uint GetPosition()
		{
			return channel.Position;
		}
	}
}
