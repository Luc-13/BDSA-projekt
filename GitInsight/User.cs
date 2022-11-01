using System.Collections;

namespace GitInsight;

public class User
{
    private ArrayList commitlist;
    public string userName { get; }

    public User(string username)
    {
        userName = username;
        commitlist = new ArrayList();
    }
}