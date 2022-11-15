namespace GitInsight.Api;

public class Repo
{
    public String? Name { get; set; }

    public List<Dictionary<String, int>>? Frequencies { get; set; }
}
