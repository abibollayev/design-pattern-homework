using System;

public class TV
{
    public void On() => Console.WriteLine("tv on");
    public void Off() => Console.WriteLine("tv off");
    public void SetChannel(int ch) => Console.WriteLine("tv channel set to " + ch);
}

public class AudioSystem
{
    public void On() => Console.WriteLine("audio system on");
    public void Off() => Console.WriteLine("audio system off");
    public void SetVolume(int vol) => Console.WriteLine("audio volume " + vol);
}

public class DVDPlayer
{
    public void On() => Console.WriteLine("dvd player on");
    public void Off() => Console.WriteLine("dvd player off");
    public void Play() => Console.WriteLine("dvd play");
    public void Pause() => Console.WriteLine("dvd pause");
    public void Stop() => Console.WriteLine("dvd stop");
}

public class GameConsole
{
    public void On() => Console.WriteLine("game console on");
    public void Off() => Console.WriteLine("game console off");
    public void StartGame(string game) => Console.WriteLine("starting game " + game);
}

