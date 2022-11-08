namespace GitInsight.Infrastructure;

public class Commit
{
    public int Id { get; set; }
    public string Message { get; }
    public DateTime Date { get; }

    public Commit(string message, DateTime date)
    {
        this.Message = message;
        this.Date = date;
    }
}
