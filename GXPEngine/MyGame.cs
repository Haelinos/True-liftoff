using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using GXPEngine.GXPEngine;
using System.Security.Policy;
using System.Runtime.Remoting.Channels;

public class MyGame : Game
{

    
    SoundChannel channel;
    EventSystem es;
    AudioManager am;
    MidiLevel midiLevel;
    Level level;
    Menu menu;
    Score score;
    EndScreen endScreen;
    //bool menuSong;
    public MyGame() : base(1366, 768, false)
    {
        score = new Score();
        menu = new Menu();
        es = new EventSystem();
        am = new AudioManager();
        endScreen= new EndScreen();
        EventSystem.instance.onLevelStart += StartLevel;
        EventSystem.instance.onLevelEnd += EndLevel;


        AddChild(menu);
    }

    void Update()
    {
        EventSystem.instance.GlobalUpdate();
        //Console.WriteLine(Score.instance.mainScore);
    }
    void StartLevel()
    {
        AudioManager.instance.StartSong("songs\\blastD.mp3");
        midiLevel = new MidiLevel("midi\\test2.mid", 800);
        AddChild(midiLevel);

    }

    void EndLevel()
    {
        AddChild(endScreen);
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}