namespace GitInsight;
using GitInsight;
using LibGit2Sharp;
using System;
using System.Text.Json;

public class Lookup
{
    string fileName = "commits.json";
    JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
    private string jsonFile;
    public void authorMode(string repopath)
    {
        List<User> userlist = new List<User>();
        var map = new Dictionary<string, User>();
        using (var repo = new Repository(repopath))

        ///Users/morten/Documents/GitHub/BDSA-projekt/GitInsight/Program.cs
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

                uservalue.commitlist.Add(
                    new GitInsight.Commit(c.Message, c.Author.When.Date));

            }
            

            foreach ((string name, User user) in map)
            {
                Console.WriteLine(user.userName);
                var histogram = from c in user.commitlist
                                group c by c.date
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
                    //Console.WriteLine(commit.Count + " " + commit.Date.ToString("yyyy-MM-dd"));
                    Console.WriteLine($"{commit.Count,6} {commit.Date:yyyy-MM-dd}");
                }
                jsonFile = JsonSerializer.Serialize(map, options);
                File.WriteAllText(fileName, jsonFile);
                Console.WriteLine("");
            }
        }

    }

    public void commitFrequency(string repopath)
    {
        
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

            foreach (var commit in histogram)
            {
                //Console.WriteLine(commit.Count + " " + commit.Date.ToString("yyyy-MM-dd"));
                Console.WriteLine($"{commit.Count,6} {commit.Date:yyyy-MM-dd}");
                

            }
            jsonFile = JsonSerializer.Serialize(histogram, options);
            File.WriteAllText(fileName, jsonFile);
            Console.WriteLine("");
        }
    }
    public void Clone(string temppath, string repopath)
    {
        var url = ("https://github.com/" + repopath);

        string newDir = Path.GetTempPath() + repopath;
        Directory.CreateDirectory(newDir);

        Repository.Clone(url, Path.Combine(temppath, newDir));
        Console.WriteLine(temppath);
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
    public void CheckRepo(string repopath, string repo)
    {
        var temppath = System.IO.Path.GetTempPath();
        var path = temppath + "/" + repopath;
        if (Directory.Exists(path))
        {
            Console.WriteLine("Repo " + repo + " already exists, fetchpulling");
            FetchPull(path);
            authorMode(path);
        }
        else
        {
            Console.WriteLine("Repo " + repo + " doesn't exist, cloning");
            Clone(temppath, repopath);
            authorMode(path);
        }
    }

    public string getJson()
    {
        return jsonFile;
    }


}