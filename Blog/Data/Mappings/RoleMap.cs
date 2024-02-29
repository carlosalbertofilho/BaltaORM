
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(role => role.Id);

            builder.Property(role => role.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(role => role.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(role => role.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(role => role.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("DATETIME");

            builder
                .HasIndex(role => role.Slug, "IX_Role_Slug")
                .IsUnique();

        }
    }
}
