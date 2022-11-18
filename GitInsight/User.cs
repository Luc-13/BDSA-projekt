using GitInsight.Infrastructure;

namespace GitInsight;

public class User
{
    public List<Commit> Commitlist { get; }

    public string Username { get; }

    public User(string username)
    {
        Username = username;
        Commitlist = new List<Commit>();
    }
}
