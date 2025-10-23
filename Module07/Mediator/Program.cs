public class ChatRoom : IMediator
{
    private readonly Dictionary<string, User> _users = new Dictionary<string, User>();

    public void Register(User user)
    {
        if (!_users.ContainsKey(user.Name))
        {
            _users[user.Name] = user;
            user.SetMediator(this);
            BroadcastNotification($"{user.Name} joined the chat", user);
        }
    }

    public void Unregister(User user)
    {
        if (_users.Remove(user.Name))
        {
            user.SetMediator(null);
            BroadcastNotification($"{user.Name} left the chat", user);
        }
    }

    public void SendMessage(string message, User from)
    {
        if (from == null || !_users.ContainsKey(from.Name)) { Console.WriteLine("user not in chat"); return; }

        foreach (var u in _users.Values)
        {
            if (u.Name == from.Name) continue;
            u.Receive(message, from.Name);
        }
    }

    public void SendPrivate(string message, User from, string toName)
    {
        if (from == null || !_users.ContainsKey(from.Name)) { Console.WriteLine("user not in chat"); return; }
        if (!_users.TryGetValue(toName, out var to)) { Console.WriteLine("recipient not found"); return; }
        to.ReceivePrivate(message, from.Name);
    }

    private void BroadcastNotification(string note, User except)
    {
        foreach (var u in _users.Values)
        {
            if (u.Name == except?.Name) continue;
            u.ReceiveSystem(note);
        }
    }
}

public class User
{
    public string Name { get; }
    private IMediator _mediator;
    public User(string name) => Name = name;
    public void SetMediator(IMediator mediator) => _mediator = mediator;
    public void Send(string message) => _mediator?.SendMessage(message, this);
    public void SendPrivate(string message, string toName) => _mediator?.SendPrivate(message, this, toName);
    public void Receive(string message, string from) => Console.WriteLine($"{Name} received from {from}: {message}");
    public void ReceivePrivate(string message, string from) => Console.WriteLine($"{Name} private from {from}: {message}");
    public void ReceiveSystem(string note) => Console.WriteLine($"{Name} system: {note}");
}

public static class Program
{
    public static void Main()
    {
        var invoker = new Invoker();


        var livingLight = new Light("living room");
        var door = new Door("front");
        var thermostat = new Thermostat(20);
        var tv = new Tv("bedroom");


        invoker.ExecuteCommand(new LightOnCommand(livingLight));
        invoker.ExecuteCommand(new DoorOpenCommand(door));
        invoker.ExecuteCommand(new IncreaseTempCommand(thermostat, 2));
        invoker.ExecuteCommand(new TvOnCommand(tv));


        invoker.UndoLast();
        invoker.UndoLastN(2);
        invoker.UndoLastN(5);


        var tea = new Tea();
        tea.PrepareRecipe();


        var coffee = new Coffee("y");
        coffee.PrepareRecipe();


        var hotChocolate = new HotChocolate();
        hotChocolate.PrepareRecipe();


        var room = new ChatRoom();
        var alice = new User("alice");
        var bob = new User("bob");
        var charlie = new User("charlie");


        room.Register(alice);
        room.Register(bob);


        alice.Send("hello everyone");
        bob.Send("hi alice");


        room.SendPrivate("this is private", bob, "alice");


        room.Register(charlie);
        charlie.Send("i joined");


        room.Unregister(bob);
        bob.Send("am i still here?");
    }
}
