using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class MidiNote
	{
		/// <summary>
		/// start of the note in ms since start of the track
		/// </summary>
		public long AbsoluteStart { get { return _absoluteStart; } }
		/// <summary>
		/// end of the note
		/// </summary>
		public long AbsoluteEnd { get { return _absoluteEnd; } }
		/// <summary>
		/// duration of the note
		/// </summary>
		public int Duration { get { return _duration; } }
		/// <summary>
		/// note pitch aka number, use that to differentiate between note lanes in the game
		/// </summary>
		public int Pitch { get { return _pitch; } }

		private long _absoluteStart;
		private long _absoluteEnd;
		private int _duration;
		private int _pitch;
		public MidiNote(long absoluteStart, long absoluteEnd, int pitch)
		{
			_absoluteStart = absoluteStart;
			_absoluteEnd = absoluteEnd;
			_duration = (int)(absoluteEnd - absoluteStart);
			_pitch = pitch;

		}
	}
}
