

using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");

            builder.HasKey(tag => tag.Id);

            builder.Property(tag => tag.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(tag => tag.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(tag => tag.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(tag => tag.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder
                .HasIndex(tag => tag.Slug, "IX_Tag_Slug")
                .IsUnique();
        }
    }
}
