namespace GitInsight;

public class Commit
{
    private string message { get;}
    private string date { get; }
    
    public Commit(string message, string date)
    {
        this.message = message;
        this.date = date;
    }
    
}