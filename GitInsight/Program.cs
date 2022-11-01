// See https://aka.ms/new-console-template for more information

using System.Collections;
using GitInsight;
using LibGit2Sharp;

List<User> userlist = new List<User>();
var map = new Dictionary<string, User>();

string workingDirectory = Environment.CurrentDirectory;
string newPath = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
using (var repo = new Repository(newPath))
    
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
            group c by c.date into h
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
            Console.WriteLine($"{commit.Count, 6} {commit.Date:yyyy-MM-dd}");
        }
        Console.WriteLine("");
    }

}

