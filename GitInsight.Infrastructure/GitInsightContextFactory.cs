using Microsoft.EntityFrameworkCore;

namespace GitInsight.Infrastructure;
public class GitInsightContextFactory
{
    public GitInsightContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GitInsightContext>();
        optionsBuilder.UseNpgsql(@"Host=127.0.0.1:54321;Username=postgres;Password=postgrespw;Database=gitinsight");

        return new GitInsightContext(optionsBuilder.Options);
    }
}
