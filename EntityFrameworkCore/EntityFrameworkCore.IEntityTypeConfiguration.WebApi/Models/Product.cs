using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.IEntityTypeConfiguration.WebApi.Models;

public sealed class Product
{
    public string Id { get; set; } = Ulid.NewUlid().ToString(); // Ulid is a NuGet package
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }

    [ForeignKey("Category")]
    public string CategoryId { get; set; } = Ulid.NewUlid().ToString();
    public Category? Category { get; set; }
}

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.Property(p => p.Id).HasColumnType("varchar(100)");//Ulid kullandığımız için Id alanını varchar(100) olarak belirtiyoruz.
        builder.Property(p => p.CategoryId).HasColumnType("varchar(100)");//Ulid kullandığımız için Id alanını varchar(100) olarak belirtiyoruz.

        builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
