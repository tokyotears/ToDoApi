using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Models;

namespace Api.DataConfigs;

public class UserConfig : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> entity) {
        entity.HasKey(u => u.Id);
        entity.Property(u => u.Name).IsRequired();
        entity.Property(u => u.HashedPassword).IsRequired();
    }
}