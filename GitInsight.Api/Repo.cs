namespace GitInsight.Api;

public class Repo
{
    public String? Name { get; set; }

    public List<Dictionary<String, dynamic>> Frequencies { get; set; } = new List<Dictionary<String, dynamic>>();
}

/* --------------------------------- Something -------------------------------- */

public class RepoResult { }

public class RepoResultFreq : RepoResult
{
    public RepoFreq Result { get; set; }

    public RepoResultFreq(RepoFreq result)
    {
        Result = result;
    }
}

public class RepoResultAuthor : RepoResult
{
    public List<RepoAuthor> Result { get; set; }

    public RepoResultAuthor(List<RepoAuthor> result)
    {
        Result = result;
    }
}

public class RepoFreq
{
    public Dictionary<string, int> Frequencies { get; set; }

    public RepoFreq(Dictionary<string, int> frequencies)
    {
        Frequencies = frequencies;
    }
}

public class RepoAuthor
{
    public RepoAuthor(String name, RepoFreq freqs)
    {
        Name = name;
        Freqs = freqs;
    }

    public String Name { get; set; }
    public RepoFreq Freqs { get; set; }
}
