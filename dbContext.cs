using Microsoft.EntityFrameworkCore;
using consoleApp.models;

public class dbContext : DbContext
{
    public DbSet<TaskItem> Task { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=todo_db");
    }
}
