using Microsoft.EntityFrameworkCore;
using KsyushaNik_kt_31_23.Database.Configurations;
using KsyushaNik_kt_31_23.Models;

namespace KsyushaNik_kt_31_23.Database;

public class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;

    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}