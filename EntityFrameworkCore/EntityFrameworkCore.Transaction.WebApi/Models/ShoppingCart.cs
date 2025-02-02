﻿namespace EntityFrameworkCore.Transaction.WebApi.Models;

public sealed class ShoppingCart
{
    public int Id { get; set; }
    public int ProductId { get; set; }//Hangi ürünü ekliyorsak onun bilgisine ihtiyacımız var.
    public Product? Product { get; set; }
    public short Quantity { get; set; }
}
