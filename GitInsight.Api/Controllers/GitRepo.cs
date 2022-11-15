using Microsoft.AspNetCore.Mvc;

namespace GitInsight.Api.Controllers;

public enum Modes
{
    Commit,
    Author
}

[ApiController]
[Route("api")]
public class GitRepoController : ControllerBase
{
    public GitRepoController() { }

    [HttpGet("{user}/{repo}")]
    public IEnumerable<Repo> Get(String user, String repo, Modes? mode = Modes.Commit)
    {
        Console.WriteLine(mode);

        var repoResult = new Repo
        {
            Name = $"{user}/{repo}"
        };

        repoResult.Frequencies = Enumerable.Range(1, 5).Select(index =>
        {
            return new Dictionary<String, int> {
                {"2017-12-08", index}
            };
        }).ToList();

        yield return repoResult;
    }
}
