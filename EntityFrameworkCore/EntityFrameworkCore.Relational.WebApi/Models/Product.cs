using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Relational.WebApi.Models;

[Index("Name", IsUnique=true)]
public sealed class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public AdditionalProduct? AdditionalProduct { get; set; }
}

public sealed class AdditionalProduct
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }//İlişkide olduğu tablonun id'sini veriyoruz
    public Product Product { get; set; }
    public string? Description { get; set; }

    [Column(TypeName="money")]
    public decimal Price { get; set; }
}