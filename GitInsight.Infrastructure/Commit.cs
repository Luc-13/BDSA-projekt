namespace GitInsight.Infrastructure;

public class Commit
{
    public int CommitId { get; set; }
    public String? Message { get; set; }
    public DateTime? Date { get; set; }
    public User? User { get; set; }
    public Repo? Repo { get; set; }

    public Commit(String message, DateTime date) { }
    public Commit(String message, DateTime date, User user, Repo repo)
    {
        Message = message;
        Date = date;
        User = user;
        Repo = repo;
    }
}
