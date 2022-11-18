using CommandLine;
using GitInsight;

internal class Program
{
    private static void Main(string[] args)
    {
        var root = Directory.GetCurrentDirectory();
        var lib = new Lib();

        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o =>
            {
                lib.SetupDatabase(args).GetAwaiter().GetResult();

                switch (o.Mode)
                {
                    case Modes.Author:
                        lib.GetCommitFrequencyByAuthorThenDate(o.RepoPath);
                        break;

                    case Modes.Frequency:
                    default:
                        lib.GetCommitFrequencyByDate(o.RepoPath);
                        break;
                }
            });
    }
}
