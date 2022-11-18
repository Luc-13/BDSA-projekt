namespace GitInsight;

using System.Text.Json;
using LibGit2Sharp;
using Commit = Infrastructure.Commit;

public class HistLine
{
    public DateTime? Date;
    public int Count;
}

public class Lookup
{
    public Dictionary<String, Dictionary<DateTime, int>> authorMode(string repopath)
    {
        List<User> userlist = new List<User>();
        var map = new Dictionary<String, User>();
        var hist = new Dictionary<String, Dictionary<DateTime, int>>();

        using (var repo = new Repository(repopath))
        {
            var headCommit = repo.Head.Commits.ToList();

            foreach (var c in headCommit)
            {
                var user = new User(c.Author.Name);
                var name = c.Author.Name;

                User? uservalue;

                if (!map.TryGetValue(name, out uservalue))
                {
                    uservalue = new User(name);
                    map[name] = uservalue;
                }

                uservalue.Commitlist.Add(
                    new Commit(c.Message, c.Author.When.Date));
            }


            foreach ((string name, User user) in map)
            {
                var histogram = from c in user.Commitlist
                                group c by c.Date
                    into h
                                let i = h.Count()
                                orderby h.Key
                                select new
                                {
                                    Date = h.Key,
                                    Count = i
                                };

                foreach (var commit in histogram)
                {
                    Console.WriteLine($"{commit.Count,6} {commit.Date:yyyy-MM-dd}");
                }

                hist.Add(name, histogram.ToDictionary(o => o.Date, o => o.Count));
            }

            return hist;
        }
    }

    public Dictionary<String, int> commitFrequency(string repopath)
    {
        var results = new Dictionary<String, int>();

        using (var repo = new Repository(repopath))
        {
            var headCommit = repo.Head.Commits.ToList();

            var histogram = from c in headCommit
                            group c by c.Author.When.Date
                into h
                            let i = h.Count()
                            orderby h.Key
                            select new
                            {
                                Date = h.Key,
                                Count = i
                            };

            foreach (var item in histogram)
            {
                results.Add(item.Date.ToString("yyyy-MM-dd"), item.Count);
            }

            // foreach (var commit in histogram)
            // {
            //     Console.WriteLine($"{commit.Count,6} {commit.Date:yyyy-MM-dd}");
            // }
            // jsonFile = JsonSerializer.Serialize(histogram, options);
            // File.WriteAllText(fileName, jsonFile);
            // Console.WriteLine("");

            return results;
        }
    }
    public string Clone(string repopath)
    {
        var url = ("https://github.com/" + repopath);
        string temppath = Path.GetTempPath();
        string newDir = temppath + repopath;
        Directory.CreateDirectory(newDir);

        Repository.Clone(url, newDir);
        return newDir;
    }

    public void FetchPull(string repopath)
    {
        using (var repo = new Repository(repopath))
        {
            var options = new FetchOptions();
            options.Prune = true;
            options.TagFetchMode = TagFetchMode.Auto;
            var remote = repo.Network.Remotes["origin"];
            var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
            Commands.Fetch(repo, remote.Name, refSpecs, options, "fetching");

            PullOptions pullOptions = new PullOptions();
            pullOptions.MergeOptions = new MergeOptions();
            pullOptions.MergeOptions.FailOnConflict = true;
            Commands.Pull(repo, new Signature(name: "main", email: "mail", when: DateTimeOffset.Now), pullOptions);
        }
    }

    public string? RepoExists(string repopath)
    {
        var temppath = System.IO.Path.GetTempPath();
        var path = temppath + "/" + repopath;

        return Directory.Exists(path) ? path : null;
    }

    public string PullRepo(string path)
    {
        var localpath = RepoExists(path);

        if (localpath is null)
        {
            return Clone(path);
        }
        else
        {
            FetchPull(localpath);
        }

        return localpath;
    }
}
