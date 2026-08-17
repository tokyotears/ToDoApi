using Api.Models;
using Api.DataConfigs;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
    public DbSet<ToDoTask> Tasks => Set <ToDoTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new ToDoTaskConfig());
    }
}