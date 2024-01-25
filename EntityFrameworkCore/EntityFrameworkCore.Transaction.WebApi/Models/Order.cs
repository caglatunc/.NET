namespace EntityFrameworkCore.Transaction.WebApi.Models;

public sealed class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? product { get; set; }
    public short Quantity { get; set; }//short is the smallest integer type in C#
    public decimal Price { get; set; }
}