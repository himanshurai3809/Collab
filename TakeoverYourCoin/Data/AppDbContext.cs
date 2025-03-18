namespace TakeoverYourCoin;

using Microsoft.EntityFrameworkCore;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ListedProject> ListedProjects { get; set; }
    public DbSet<Vote> Votes { get; set; }
}

