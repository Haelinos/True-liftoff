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
    Sprite background;
    EventSystem es;
    AudioManager am;
    MidiLevel level;

    Sprite laser_cyan;
    Sprite laser_purple;
    Sprite laser_yellow;
    public MyGame() : base(1366, 768, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        es = new EventSystem();
        am = new AudioManager();
        level = new MidiLevel("midi\\alwaysThen.mid", 0);
        musicDisk = new MusicDisk(0.55f);
        AudioManager.instance.StartSong("songs\\alwaysThen.mp3");

        laser_cyan = new Sprite("sprites\\laser_cyan.png");
        laser_cyan.SetOrigin(laser_cyan.width/2, laser_cyan.height /2);
        laser_cyan.SetXY(400, this.height/2);
        laser_cyan.rotation = 90;

        laser_purple = new Sprite("sprites\\laser_purple.png");
        laser_purple.SetOrigin(laser_purple.width / 2, laser_purple.height / 2);
        laser_purple.SetXY(1000, this.height / 2);
        laser_purple.rotation = 90;

        laser_yellow = new Sprite("sprites\\laser_yellow.png");
        laser_yellow.SetOrigin(laser_yellow.width / 2, laser_yellow.height / 2);
        laser_yellow.SetXY(700, this.height / 2);
        laser_yellow.rotation = 90;

        background = new Sprite("sprites\\stage.png");
        background.SetOrigin(background.width / 2, background.height / 2);
        background.SetXY(this.width / 2, this.height / 2);
        background.scale = 1f;


        AddChild(background);
        AddChild(laser_cyan);
        AddChild(laser_purple);
        AddChild(laser_yellow);

        AddChild(musicDisk);
        musicDisk.SetXY(width/2, height/2 + 500);

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