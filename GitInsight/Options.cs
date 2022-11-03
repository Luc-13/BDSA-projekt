namespace GitInsight;

using System;
using CommandLine;

public enum Modes
{
    Author,
    Frequency,
    author = Author,
    frequency = Frequency,
    a = Author,
    f = Frequency
}

public class Options
{
    [Value(0, Required = true, MetaName = "Path", HelpText = "get a path or smth", Default = ".")]
    public string RepoPath { get; set; } = ".";
    
    [Option('m', "mode", Required = true, HelpText = "Set to author or Frequency mode, frequency mode is default.", Default = Modes.Frequency)]
    public Modes Mode { get; set; }
}
