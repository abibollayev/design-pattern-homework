public class Light
{
    public string Location { get; }
    public bool IsOn { get; private set; }
    public Light(string location) => Location = location;
    public void On() { IsOn = true; Console.WriteLine($"light {Location} turned on"); }
    public void Off() { IsOn = false; Console.WriteLine($"light {Location} turned off"); }
}

public class LightOffCommand : ICommand
{
    private readonly Light _light;
    public LightOffCommand(Light light) => _light = light;
    public void Execute() => _light.Off();
    public void Undo() => _light.On();
}

public class DoorOpenCommand : ICommand
{
    private readonly Door _door;
    public DoorOpenCommand(Door door) => _door = door;
    public void Execute() => _door.Open();
    public void Undo() => _door.Close();
}

public class DoorCloseCommand : ICommand
{
    private readonly Door _door;
    public DoorCloseCommand(Door door) => _door = door;
    public void Execute() => _door.Close();
    public void Undo() => _door.Open();
}

public class IncreaseTempCommand : ICommand
{
    private readonly Thermostat _thermostat;
    private readonly double _delta;
    public IncreaseTempCommand(Thermostat thermostat, double delta) { _thermostat = thermostat; _delta = delta; }
    public void Execute() => _thermostat.Increase(_delta);
    public void Undo() => _thermostat.Decrease(_delta);
}

public class DecreaseTempCommand : ICommand
{
    private readonly Thermostat _thermostat;
    private readonly double _delta;
    public DecreaseTempCommand(Thermostat thermostat, double delta) { _thermostat = thermostat; _delta = delta; }
    public void Execute() => _thermostat.Decrease(_delta);
    public void Undo() => _thermostat.Increase(_delta);
}

public class TvOnCommand : ICommand
{
    private readonly Tv _tv;
    public TvOnCommand(Tv tv) => _tv = tv;
    public void Execute() => _tv.TurnOn();
    public void Undo() => _tv.TurnOff();
}

public class TvOffCommand : ICommand
{
    private readonly Tv _tv;
    public TvOffCommand(Tv tv) => _tv = tv;
    public void Execute() => _tv.TurnOff();
    public void Undo() => _tv.TurnOn();
}

public class Invoker
{
    private readonly Stack<ICommand> _history = new Stack<ICommand>();
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void UndoLast()
    {
        if (_history.Count == 0) 
        {
            Console.WriteLine("no commands to undo");
            return;
        }

        var cmd = _history.Pop();
        cmd.Undo();
    }

    public void UndoLastN(int n)
    {
        if (n <= 0) return;
        for (int i = 0; i < n; i++) UndoLast();
    }
}
