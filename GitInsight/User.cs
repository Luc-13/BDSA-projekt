using System.Collections;

namespace GitInsight;

public class User
{
    public List<Commit> commitlist;
    public string userName { get; }

    public User(string username)
    {
        userName = username;
        commitlist = new List<Commit>();
    }

    public int getTotalCommits()
    {
        return commitlist.Count;
    }
}