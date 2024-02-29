

using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Especifica o nome da Tabela
            // equivale ao [Table("Category")] do EF6
            builder.ToTable("Category");

            // Mapeia a chave primária
            // equivale ao [Key] do EF6
            builder.HasKey(category => category.Id);

            // Mapeia o campo Id como autoincremento
            // equivale ao [DatabaseGenerated(DatabaseGeneratedOption.Identity)] do EF6
            builder.Property(category => category.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // IDENTITY(1,1)

            // Mapeia o campo Name como nvarchar(80)
            // equivale ao [StringLength(80)] do EF6
            builder.Property(category => category.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            // Mapeia o campo Slug como nvarchar(80)
            builder.Property(category => category.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            // Mapeia o índice único para o campo Slug
            builder.HasIndex(category => category.Slug, "IX_Category_Slug")
                .IsUnique();
        }
    }
}
