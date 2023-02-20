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
    AudioManager am;
    MidiLevel level;
    public MyGame() : base(1366, 768, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        es = new EventSystem();
        am = new AudioManager();
        musicDisk = new MusicDisk(0.55f);
        AudioManager.instance.StartSong("songs\\alwaysThen.mp3");
        AddChild(musicDisk);
        musicDisk.SetXY(width/2, height/2 + 700);
        level = new MidiLevel("midi\\alwaysThen.mid", 700);
        AddChild(level);
    }

    void Update()
    {
        EventSystem.instance.GlobalUpdate();

    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}