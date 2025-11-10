using System;

class Program
{
    static void Main()
    {
        var tv = new TV();
        var audio = new AudioSystem();
        var dvd = new DVDPlayer();
        var console = new GameConsole();
        var home = new HomeTheaterFacade(tv, audio, dvd, console);

        home.WatchMovie();
        home.AdjustVolume(8);
        home.StopMovie();

        home.PlayGame("halo");
        home.StopGame();

        home.ListenMusic();
        home.Shutdown();
    }
}

