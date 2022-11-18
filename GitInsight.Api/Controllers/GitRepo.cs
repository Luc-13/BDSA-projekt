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
    Lookup _lookup = new Lookup();

    public GitRepoController() { }

    [HttpGet("{user}/{repo}")]
    public IEnumerable<Repo> Get(String user, String repo, Modes? mode = Modes.Commit)
    {
        var url = $"{user}/{repo}";

        String localpath = _lookup.PullRepo(url);

        var freq = new Dictionary<String, int>();
        var auth = new Dictionary<String, Dictionary<DateTime, int>>();

        var newfreq = (Dictionary<String, dynamic>) Convert.ChangeType(freq, typeof(Dictionary<String, dynamic>));

        var repoResult = new Repo
        {
            Name = $"{user}/{repo}"
        };

        switch (mode)
        {
            case Modes.Commit:
                freq = _lookup.commitFrequency(localpath);
                repoResult.Frequencies.Add(
                    newfreq
                );
                break;

            case Modes.Author:
                auth = _lookup.authorMode(localpath);

                Console.WriteLine(auth);

                foreach ((string name, Dictionary<DateTime, int> hist) in auth)
                {
                    repoResult.Frequencies.Add(
                        new Dictionary<String, dynamic>(){
                            {name, hist}
                        }
                    );
                }
                break;
        }

        yield return repoResult;
    }
}
