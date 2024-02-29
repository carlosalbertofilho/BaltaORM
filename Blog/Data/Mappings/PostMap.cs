
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(post => post.Id);

            builder.Property(post => post.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(post => post.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);

            builder.Property(post => post.Summary)
                .IsRequired()
                .HasColumnName("Summary")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(post => post.Body)
                .IsRequired()
                .HasColumnName("Body")
                .HasColumnType("TEXT");

            builder.Property(post => post.Image)
                .IsRequired()
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(post => post.CreateDate)
                .IsRequired()
                .HasColumnName("CreateDate")
                .HasColumnType("DATETIME");

            builder.Property(post => post.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("DATETIME");

            builder.Property(post => post.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);
        }
    }
}
