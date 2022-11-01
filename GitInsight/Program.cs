// See https://aka.ms/new-console-template for more information

using LibGit2Sharp;

string workingDirectory = Environment.CurrentDirectory;
string newPath = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
using (var repo = new Repository(newPath))
    
    ///Users/morten/Documents/GitHub/BDSA-projekt/GitInsight/Program.cs
{
    
    var headCommit = repo.Head.Commits.ToList();
    foreach (var c in headCommit)
    {
        Console.WriteLine(c.Author.Name + " " + c.Author.When.Date.Day + "/" + c.Author.When.Date.Month);
        
        
    }
    //Console.WriteLine(headCommit);
    
}

