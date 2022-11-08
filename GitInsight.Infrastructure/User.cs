namespace GitInsight.Infrastructure;

public class User
{
    public int Id { get; set; }
    public List<Commit> commitlist;
    public string Username { get; }

    public User(string username)
    {
        Username = username;
        commitlist = new List<Commit>();
    }

    public int getTotalCommits()
    {
        return commitlist.Count;
    }
}
