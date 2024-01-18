namespace EntityFrameworkCore.OnModelCreating.WebApi.Models;

public sealed class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; } 
}

public sealed class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public sealed class User 
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
