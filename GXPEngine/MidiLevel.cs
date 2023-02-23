using GXPEngine.GXPEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class MidiLevel : GameObject
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
		public float LevelSpeed { get; set; }

		private int firstNoteNumber;
		private List<MidiNote> _notes= new List<MidiNote>();
		public List<Note> drawnNotes = new List<Note>();

		public MidiLevel(string path, float offset)
		{
			MusicDisk musicDisk = new MusicDisk(0.55f);
			AddChildAt(musicDisk, 10);
			musicDisk.SetXY(game.width / 2, game.height / 2 + 500);
			_notes = MidiParser.Parse(path, out firstNoteNumber);
			GlobalOffset = offset;
			EventSystem.instance.onUpdate += LevelUpdate;
			LevelSpeed = 3f;
		}
		private void LevelUpdate()
		{
			if (AudioManager.instance.GetPosition() >= _notes.First().AbsoluteStart - GlobalOffset)
			{
				Note note = new Note(_notes.First().Pitch - firstNoteNumber, LevelSpeed, _notes.First().AbsoluteEnd, _notes.First().Color);
				drawnNotes.Add(note);
				AddChildAt(note, 110);
				_notes.RemoveAt(0);
			}
		}
	}
}
