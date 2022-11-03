// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.ComponentModel;
using CommandLine;
using GitInsight;
using LibGit2Sharp;
var lookup = new Lookup();
Parser.Default.ParseArguments<Options>(args)
    .WithParsed(o =>
    {
        Console.WriteLine(o.RepoPath);
        if (o.Mode == Modes.Author)
        {
            lookup.authorMode(o.RepoPath);
        }
        else
        {
            lookup.commitFrequency(o.RepoPath);
        }
    });

//lookup.authorMode();
//lookup.commitFrequency();

