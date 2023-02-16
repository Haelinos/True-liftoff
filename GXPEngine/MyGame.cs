using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using GXPEngine.GXPEngine;
using System.Security.Policy;

public class MyGame : Game
{

    MusicDisk musicDisk;
    Note notes;
    //Level level;
    //EasyDraw turnTable;
    public MyGame() : base(1920, 1080, false)     // Create a window that's 800x600 and NOT fullscreen
    {

        //level = new Level(musicDisk);
        musicDisk = new MusicDisk();
        Console.WriteLine("pp");
        //AddChild(level);

        AddChild(musicDisk);
        SetXY(960, 1300);

        for (int i = 0; i < 4; i++) 
        {
            notes = new Note(musicDisk);
            AddChild(notes);
        }

        //TurnTable();
    }

    // For every game object, Update is called every frame, by the engine:
    void Update()
    {
        //EventSystem.instance.Collision();
        //EventSystem.instance.Click();
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}