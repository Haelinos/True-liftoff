using GXPEngine.GXPEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Level : GameObject
	{
        private List<MidiNote> _notes = new List<MidiNote>();

		private List<Note> _currentActiveNotes = new List<Note>();

		private float _speed = 0f;
		private long _offset = 0;
		private int _currentBeatNumber = 0;

		private float _currentTime = 0f;
		private float _currentMillisecondsPerBeat = 0f;

        private AudioManager _currentSong;

		Sprite _debug = null;

		//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//																			Level()
		//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public Level(string songName, int bpm, long offset)
		{

			StartSong(songName, bpm, offset);
		}

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //																			StartSong()
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void StartSong(string songName, int bpm, long offset)
		{
            _notes = MidiParser.Parse(Constants.DataFolder + songName + Constants.DataExtension);

            _currentSong = new AudioManager(Constants.SongFolder + songName + Constants.SongExtension);
            _currentSong.StartSong();
           
			_speed = 0.5f;
			_offset = offset;

			_currentTime = 0f;
			_currentMillisecondsPerBeat = 60000f / bpm;  // ? 60000f / bpm doens't work?

			_debug = new Sprite("sprites/circle_blue.png");
			AddChild(_debug);
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //																			updateBeatNumber()
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void updateBeatNumber()
		{
            _currentTime += Time.deltaTime;
			_currentBeatNumber = (int)Mathf.Floor(_currentTime * Constants.TicsPerLine / _currentMillisecondsPerBeat);// / Constants.TicsPerLine);/// _currentMillisecondsPerBeat);

			_debug.visible = (_currentBeatNumber % 4 == 0);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //																			updateNotes()
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void updateNotes(float speed)
		{
            foreach (var note in _currentActiveNotes)
            {
                note.Step(_currentBeatNumber, _speed);
            }

        }

		//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//																			Update()
		//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		private void Update()
		{
			updateBeatNumber();
			updateNotes(_speed);
			progressSongPosition();
		}

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //																			progressSongPosition()
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void progressSongPosition()
		{
			if (_notes.Count < 1)
			{
				Console.WriteLine("Warning: NO MORE NOTES");
				return;
			}

			MidiNote currentNote = _notes.First();
			if (currentNote != null)
			{
				int duration = currentNote.Duration;
				int pitch = currentNote.Pitch - Constants.FirstNote;
				long startPosition = currentNote.AbsoluteStart - _offset;

				float speed = _speed;

				if (_currentSong.GetPosition() >= startPosition)
                {
					Note note = new Note(_currentBeatNumber, pitch, duration, speed);
					_currentActiveNotes.Add(note);
					AddChild(note);

					_notes.RemoveAt(0);
				}
			}
		}
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //																			SpawnNote()
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SpawnNote(float duration, int noteNumber)
		{
			float length = _speed * duration/1000 * Time.deltaTime * 30;
			int lane = noteNumber - Constants.FirstNote;
			float x = 400 + 300 * lane;
			float y = -100;
			EasyDraw ed = new EasyDraw(50, (int)length, false);
			ed.SetOrigin(25, (int)length);
			ed.SetXY(x, y);
			ed.Clear(Color.AliceBlue);
			AddChild(ed);
		}

	}
}
