namespace GitInsight.Infrastructure;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public List<Commit> Commits;
    public List<Repo> Repos;

    public User(string username)
    {
        Username = username;
        Commits = new List<Commit>();
        Repos = new List<Repo>();
    }

    public int getTotalCommits()
    {
        return Commits.Count;
    }
}
