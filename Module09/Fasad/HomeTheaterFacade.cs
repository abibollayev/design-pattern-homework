using System;

public class HomeTheaterFacade
{
    private TV tv;
    private AudioSystem audio;
    private DVDPlayer dvd;
    private GameConsole console;

    public HomeTheaterFacade(TV tv, AudioSystem audio, DVDPlayer dvd, GameConsole console)
    {
        this.tv = tv;
        this.audio = audio;
        this.dvd = dvd;
        this.console = console;
    }

    public void WatchMovie()
    {
        Console.WriteLine("--- start movie mode ---");
        tv.On();
        audio.On();
        dvd.On();
        audio.SetVolume(5);
        dvd.Play();
    }

    public void StopMovie()
    {
        Console.WriteLine("--- stop movie mode ---");
        dvd.Stop();
        dvd.Off();
        audio.Off();
        tv.Off();
    }

    public void PlayGame(string game)
    {
        Console.WriteLine("--- start game mode ---");
        tv.On();
        audio.On();
        console.On();
        audio.SetVolume(6);
        console.StartGame(game);
    }

    public void StopGame()
    {
        Console.WriteLine("--- stop game mode ---");
        console.Off();
        audio.Off();
        tv.Off();
    }

    public void ListenMusic()
    {
        Console.WriteLine("--- start music mode ---");
        tv.On();
        audio.On();
        audio.SetVolume(4);
        Console.WriteLine("tv input set to audio");
    }

    public void AdjustVolume(int v)
    {
        audio.SetVolume(v);
    }

    public void Shutdown()
    {
        Console.WriteLine("--- shutting down all devices ---");
        tv.Off();
        audio.Off();
        dvd.Off();
        console.Off();
    }
}

