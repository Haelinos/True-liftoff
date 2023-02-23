using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Midi;
using static System.Net.Mime.MediaTypeNames;

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
			float ticksPerQuartNote = mf.DeltaTicksPerQuarterNote;
			float tempo = 0;
			for (int i = 0; i < mf.Tracks; i++)
			{
				foreach (var midiEvent in mf.Events[i])
				{
					if (midiEvent is TempoEvent tempoEvent)
					{
						tempo = 130f;
					}
					else if (MidiEvent.IsNoteOn(midiEvent))
					{
						NoteEvent ne = (NoteEvent)midiEvent;
						noteOnEvents.Add(ne);
						if (ne.NoteNumber < firstNote)
						{
							firstNote = ne.NoteNumber;
						}
						int millis = (int)(60000 / (tempo * ticksPerQuartNote));
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
			var colorPath = Path.GetDirectoryName(
	  System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
			colorPath = colorPath.Substring(6);
			string[] noteColors = File.ReadAllLines(colorPath + @"\data.txt");
			for (int i = 0; i < noteOnEvents.Count; i++)
			{
				long absoluteStartMillis = (long)(60000 / (tempo * ticksPerQuartNote) * noteOnEvents[i].AbsoluteTime);
				long absoluteEndMillis = (long)(60000 / (tempo * ticksPerQuartNote) * noteOffEvents[i].AbsoluteTime);
				returnList.Add(new MidiNote(absoluteStartMillis, absoluteEndMillis, noteOnEvents[i].NoteNumber, int.Parse(noteColors[i])-1));
			}
			return returnList;
 		}
	}
}
