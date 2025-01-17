using Grinch.Core.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace Grinch.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Database=Grinch;User=root;Password=setyourpass;",
            new MySqlServerVersion(new Version(8, 0, 31)));
    }

    public DbSet<Group> Groups { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<GroupUser> GroupUsers { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}