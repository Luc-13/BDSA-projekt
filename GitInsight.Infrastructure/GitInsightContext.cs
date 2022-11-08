using Microsoft.EntityFrameworkCore;

namespace GitInsight.Infrastructure;
public class GitInsightContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Commit> Commits => Set<Commit>();

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");

    public GitInsightContext(DbContextOptions<GitInsightContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
