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
		private List<EasyDraw> drawnNotes = new List<EasyDraw>();

		public MidiLevel(string path, float offset)
		{
			_notes = MidiParser.Parse(path);
			GlobalOffset = offset;
			EventSystem.instance.onUpdate += Update;
			firstNoteNumber = 71;
			LevelSpeed = 2;
		}
		private void Update()
		{
			foreach (var note in drawnNotes)
			{
				note.Move(0, LevelSpeed);
			}
			if (AudioManager.instance.GetPosition() >= _notes.First().AbsoluteStart - GlobalOffset)
			{
				SpawnNote(_notes.First().Duration, _notes.First().Pitch);
				_notes.RemoveAt(0);
			}
		}
		private void SpawnNote(float duration, int noteNumber)
		{
			Console.WriteLine(duration);
			float length = LevelSpeed * duration/1000 * Time.deltaTime * 30;
			int lane = noteNumber - firstNoteNumber;
			float x = 400 + 300 * lane;
			float y = -100;
			EasyDraw ed = new EasyDraw(50, (int)length, false);
			ed.SetOrigin(25, (int)length);
			ed.SetXY(x, y);
			ed.Clear(Color.AliceBlue);
			AddChild(ed);
			drawnNotes.Add(ed);
		}

	}
}
