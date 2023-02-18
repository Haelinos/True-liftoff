using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using GXPEngine.GXPEngine;
using System.Security.Policy;
using System.Runtime.Remoting.Channels;

public class MyGame : Game
{

    MusicDisk musicDisk;
    Note notes;
    SoundChannel channel;
    EventSystem es;
    float msPerBeat;
    float bpm = 122;
    int beat;
    int lastBeat;
    public MyGame() : base(1366, 768, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        es = new EventSystem();
        //level = new Level(musicDisk);
        musicDisk = new MusicDisk();
        //AddChild(level);

        AddChild(musicDisk);
        musicDisk.SetXY(width/2, height/2 + 700);

        channel = new Sound("songs\\blast.mp3").Play();
        msPerBeat = 1000f / (bpm / 60f);
    }

    void Update()
    {
        EventSystem.instance.GlobalUpdate();
        notes = new Note(musicDisk);
        BeatHandler.ChangeBeat(channel, msPerBeat);
        Console.WriteLine("Beat: " + BeatHandler.GetBeat());
        beat = BeatHandler.GetBeat();

        if (beat != lastBeat)
        {
            AddChild(notes);
            lastBeat = beat;
        }

    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}