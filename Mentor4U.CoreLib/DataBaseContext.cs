using Mentor4U.CoreLib.Models;

using Microsoft.EntityFrameworkCore;

namespace Mentor4U.CoreLib;

public class DataBaseContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; } 
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options) 
        : base(options) 
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Account>()
            .HasOne(a => a.User)
            .WithOne(u => u.Account)
            .HasForeignKey<User>(u => u.AccountId)
            .IsRequired();
        
        modelBuilder
            .Entity<User>()
            .HasIndex(u => u.AccountId)
            .IsUnique();
    }
}