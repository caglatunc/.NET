using EntityFrameworkCore.OnModelCreating.WebApi.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.OnModelCreating.WebApi.Models;

[Index("Name", IsUnique = true)]  
public sealed class Product:Entity
{
    [Column(TypeName = "varchar(200)")]
    [Required]
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "money")]
    [Required]
    public decimal Price { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; } 
}

public sealed class Category : Entity
{
    public string Name { get; set; } = string.Empty;
   
}

public sealed class User : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
