using Microsoft.EntityFrameworkCore;

namespace OrderProvider.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>().HasData(new
        {
            Id = "1",
            Name = "Kimmo Doe",
        });

        modelBuilder.Entity<Order>().HasData(new
        {
            Id = "2",
            Name = "William Doe",
        });

        modelBuilder.Entity<Order>().HasData(new
        {
            Id = "3",
            Name = "Sörén Doe",
        });
    }
}