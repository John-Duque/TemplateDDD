using TemplateDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TemplateDDD.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(60);
        }
    }
}
