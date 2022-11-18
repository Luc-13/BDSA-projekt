namespace GitInsight.Infrastructure;

public class Repo
{
    public int RepoId { get; set; }
    public String? Title { get; set; }
    public List<Commit>? Commits;
    public User? Owner;
    public List<User>? Contributers;

    public Repo() { }
    public Repo(String title, User owner)
    {
        Title = title;
        Commits = new List<Commit>();
        Owner = owner;
        Contributers = new List<User>();
    }
}
