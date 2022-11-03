namespace GitInsight;
using System;
using CommandLine;

public enum Modes
{
    Author,
    Frequency
}
public class Options
{
    [Value(0, Required = true, MetaName = "Path", HelpText = "get a path or smth")]
    public string RepoPath { get; set; }
    
    [Option('m', "mode", Required = true, HelpText = "Select which output mode")]
    public Modes Mode { get; set; }
}