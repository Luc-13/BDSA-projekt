using GitInsight.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GitInsight;
public class GitInsightContextFactory : IDesignTimeDbContextFactory<GitInsightContext>
{
    public GitInsightContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var connectionString = configuration.GetConnectionString("GitInsight");

        var optionsBuilder = new DbContextOptionsBuilder<GitInsightContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new GitInsightContext(optionsBuilder.Options);
    }
}
