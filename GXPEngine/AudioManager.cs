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

		private SoundChannel _channel;
		private Sound _sound;

		public AudioManager(string path)
		{
			_sound = new Sound(path);
		}

		public void StartSong()
		{
			_channel = _sound.Play();
		}

		public uint GetPosition()
		{
			return _channel.Position;
		}
	}
}
