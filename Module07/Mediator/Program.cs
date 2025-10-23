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
