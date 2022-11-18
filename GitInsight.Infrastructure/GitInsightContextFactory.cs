using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GitInsight.Infrastructure;

public class GitInsightContextFactory : IDesignTimeDbContextFactory<GitInsightContext>
{
    public GitInsightContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GitInsightContext>();
        optionsBuilder.UseNpgsql(@"Host=127.0.0.1:54320;Username=root;Password=root;Database=gitinsight");

        return new GitInsightContext(optionsBuilder.Options);
        // return new GitInsightContext();
    }
}
