using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Midi;

namespace GXPEngine
{
	internal class MidiParser
	{
		public static List<MidiNote> Parse(string path, out int firstNote)
		{
			firstNote = int.MaxValue;
			List<MidiNote> returnList = new List<MidiNote>();
			List<NoteEvent> noteOnEvents = new List<NoteEvent>();
			List<NoteEvent> noteOffEvents = new List<NoteEvent>();
			var mf = new MidiFile(path, false);
			int ticksPerQuartNote = mf.DeltaTicksPerQuarterNote;
			int tempo = 0;
			for (int i = 0; i < mf.Tracks; i++)
			{
				foreach (var midiEvent in mf.Events[i])
				{
					if (midiEvent is TempoEvent tempoEvent)
					{
						tempo = (int)tempoEvent.Tempo;
					}
					else if (MidiEvent.IsNoteOn(midiEvent))
					{
						NoteEvent ne = (NoteEvent)midiEvent;
						noteOnEvents.Add(ne);
						if (ne.NoteNumber < firstNote)
						{
							firstNote = ne.NoteNumber;
						}
						int millis = 60000 / (tempo * ticksPerQuartNote);
						//Console.WriteLine(millis * midiEvent.AbsoluteTime +  "  " + ne.NoteNumber);
					}
					else if(MidiEvent.IsNoteOff(midiEvent))
					{
						NoteEvent ne = (NoteEvent)midiEvent;
						noteOffEvents.Add(ne);
					}
				}
			}
			if (noteOnEvents.Count != noteOffEvents.Count)
			{
				throw new Exception("Some notes doesn't have start or end");
			}
			for (int i = 0; i < noteOnEvents.Count; i++)
			{
				long absoluteStartMillis = 60000 / (tempo * ticksPerQuartNote) * noteOnEvents[i].AbsoluteTime;
				long absoluteEndMillis = 60000 / (tempo * ticksPerQuartNote) * noteOffEvents[i].AbsoluteTime;
				returnList.Add(new MidiNote(absoluteStartMillis, absoluteEndMillis, noteOnEvents[i].NoteNumber));
			}
			return returnList;
 		}
	}
}
