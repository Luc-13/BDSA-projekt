namespace GitInsight;

public class Commit
{
    public string message { get;}
    public DateTime date { get; }
    
    public Commit(string message, DateTime date)
    {
        this.message = message;
        this.date = date;
    }
}
