using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class MidiLevel
	{
		public List<MidiNote> Notes { get { return _notes; } }
		/// <summary>
		/// use this to offset ends of all notes on the level
		/// </summary>
		public float NoteEndOffset { get; set; }
		/// <summary>
		/// overall offset which can either be positive (notes falling with delay) or negative (music starts with delay)
		/// </summary>
		public float GlobalOffset { get; set; }
		private List<MidiNote> _notes= new List<MidiNote>();

		public MidiLevel()
		{

		}
	}
}
