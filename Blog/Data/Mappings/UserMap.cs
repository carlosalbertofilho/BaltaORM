

using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(user => user.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(user => user.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(user => user.Bio)
                .IsRequired()
                .HasColumnName("Bio")
                .HasColumnType("TEXT");

            builder.Property(user => user.Image)
                .IsRequired()
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(user => user.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder
                .HasIndex(user => user.Slug, "IX_User_Slug")
                .IsUnique();

            builder
                .HasIndex(user => user.Email, "IX_User_Email")
                .IsUnique();

        }
    }
}
