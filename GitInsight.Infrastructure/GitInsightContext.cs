using Microsoft.EntityFrameworkCore;

namespace GitInsight.Infrastructure;
public class GitInsightContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Repo> Repos => Set<Repo>();
    public DbSet<Commit>? Commits { get; set; }
    // public DbSet<Blog> Blogs { get; set; }
    // public DbSet<Post> Posts { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseNpgsql("Host=localhost:54320;Database=gitinsight;Username=root;Password=root");

    public GitInsightContext(DbContextOptions<GitInsightContext> options)
        : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    // }
}
