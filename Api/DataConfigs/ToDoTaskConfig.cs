using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.DataConfigs;

public class ToDoTaskConfig : IEntityTypeConfiguration<ToDoTask> {
    public void Configure(EntityTypeBuilder<ToDoTask> entity) {
        entity.HasKey(t => t.Id);
        entity.Property(t => t.Name).IsRequired();
        entity.Property(t => t.Task).IsRequired();
        entity.Property(t => t.Status).IsRequired().HasConversion<string>();
    }
}