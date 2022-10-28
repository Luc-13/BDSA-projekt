// See https://aka.ms/new-console-template for more information

using LibGit2Sharp;

string workingDirectory = Environment.CurrentDirectory;
string newPath = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
using (var repo = new Repository(newPath))
    
    ///Users/morten/Documents/GitHub/BDSA-projekt/GitInsight/Program.cs
{
    
    var headCommit = repo.Head.Commits.First();
    Console.WriteLine(headCommit);
    
}

