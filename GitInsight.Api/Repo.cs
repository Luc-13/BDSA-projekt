namespace GitInsight.Api;

public class Repo
{
    public String? Name { get; set; }

    public List<Dictionary<String, dynamic>> Frequencies { get; set; } = new List<Dictionary<String, dynamic>>();
}
