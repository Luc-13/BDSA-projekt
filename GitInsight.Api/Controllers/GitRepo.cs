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
    Lib _lib = new Lib();

    public GitRepoController() { }

    [HttpGet("{user}/{repo}")]
    public IEnumerable<Repo> Get(String user, String repo, Modes? mode = Modes.Commit)
    {
        var url = $"https://github.com/{user}/{repo}";

        switch (mode)
        {
            case Modes.Commit:
                _lib.GetCommitFrequencyByDate(url);
                break;
            case Modes.Author:
                _lib.GetCommitFrequencyByAuthorThenDate(url);
                break;
        }

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
