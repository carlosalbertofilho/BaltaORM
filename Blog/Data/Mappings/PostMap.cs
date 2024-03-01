
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
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.Property(post => post.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.Property(post => post.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            // Mapeia o relacionamento com a tabela de Usuário
            // 1 Post tem 1 Autor
            builder.HasOne<User>(post => post.Author)
                .WithMany(user => user.Posts)
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade);

            // Mapeia o relacionamento com a tabela de Categoria
            // 1 Post tem 1 Categoria
            builder.HasOne<Category>(post => post.Category)
                .WithMany(category => category.Posts)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);

            // Mapeia o relacionamento com a tabela de Tag
            // 1 Post tem N Tags
            builder.HasMany<Tag>(post => post.Tags)
                .WithMany(tag => tag.Posts)
                .UsingEntity(j => j.ToTable("PostTag"));
        }
    }
}
