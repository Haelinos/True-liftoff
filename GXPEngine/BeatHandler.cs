using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public static class BeatHandler
{
    public static int beat = 0;

    public static int ChangeBeat(SoundChannel song, float msPerBeat)
    {
        if (song.Position >= beat * msPerBeat)
        {   
            beat++;
            Console.WriteLine(beat);
        }

        return beat;
    }

    public static int GetBeat()
    {
        return beat;
    }
}