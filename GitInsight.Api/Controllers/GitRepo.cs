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
    public ActionResult<dynamic> Get(String user, String repo, Modes? mode = Modes.Commit)
    {
        var url = $"{user}/{repo}";

        String localpath = _lookup.PullRepo(url);

        // var repoResult = new Repo
        // {
        //     Name = $"{user}/{repo}"
        // };

        // var dict = new Dictionary<DateTime, int>
        // {
        //     [new DateTime()] = 9
        // };

        // var f = new RepoFreq(dict);
        // var name = "wut";

        // // SKAL VÆRE LISTE I STEET LMAO

        // var a = new RepoAuthor(name, f);

        // var res = new RepoResultAuthor(new List<RepoAuthor>(){
        //     a
        // });

        dynamic res;

        switch (mode)
        {
            case Modes.Author:
                var dict = _lookup.authorMode(localpath);
                //fix this
                var f = new RepoFreq(dict);
                var name = "wut";

                // SKAL VÆRE LISTE I STEET LMAO

                var a = new RepoAuthor(dict);

                res = new RepoResultAuthor(new List<RepoAuthor>(){
                    a
                });

                // auth = _lookup.authorMode(localpath);

                // Console.WriteLine(auth);

                // foreach ((string name, Dictionary<DateTime, int> hist) in auth)
                // {
                //     repoResult.Frequencies.Add(
                //         new Dictionary<String, dynamic>(){
                //             {name, hist}
                //         }
                //     );
                // }
                break;

            default:
            case Modes.Commit:
                var dict2 = _lookup.commitFrequency(localpath);

                var f2 = new RepoFreq(dict2);

                res = new RepoResultFreq(f2);
                break;

        }

        return res;
    }
}
