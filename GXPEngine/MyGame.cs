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
    Score score;
    SoundChannel channel;
    EventSystem es;
    AudioManager am;
    MidiLevel level;
    Sprite background; //change to animationsprite
    public MyGame() : base(1366, 768, false)
    {
        es = new EventSystem();
        am = new AudioManager();
        score = new Score();
        level = new MidiLevel("midi\\alwaysThen.mid", 0);
        AudioManager.instance.StartSong("songs\\alwaysThen.mp3");


        background = new Sprite("sprites\\stage.png");
        background.SetOrigin(background.width / 2, background.height / 2);
        background.SetXY(width/2, height/2 );
        AddChild(background);

        musicDisk = new MusicDisk(0.55f);
        AddChild(musicDisk);
        musicDisk.SetXY(width / 2, height / 2 + 500);


        AddChild(level);
        AddChild(score);
        
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