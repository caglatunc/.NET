using Bogus;
using EntityFrameworkCore.Transaction.WebApi.Context;
using EntityFrameworkCore.Transaction.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Transaction.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController(AppDbContext context): ControllerBase
{
    [HttpGet]
    public IActionResult SeedData()
    {
        List<Product> products = new();
        List<ShoppingCart> shoppingCarts = new();

        for (int i = 0; i < 10; i++)
        {
            Faker faker = new();
            Product product = new()
            {
                Name = faker.Commerce.ProductName(),
                Price = faker.Random.Decimal(1, 1000),
                Quantity = 10
            };
            products.Add(product);
        }
        //Toplu bir şekilde bir listeye kaydedilen bir metot.
        context.AddRange(products);

        for (int i=1; i<5; i++)
        {
            ShoppingCart shoppingCart = new()
            {
                ProductId = i,
                Quantity = (short)i
            };
             shoppingCarts.Add(shoppingCart);
        }
       context.AddRange(shoppingCarts);
       context.SaveChanges();
       

        return NoContent();
    }

    [HttpGet]

    //Sepetteki ürünleri siparişe çevirdiğimiz senaryoda:
    public IActionResult CreateOrder()
    {
        //İlk,Sepetimdeki tüm ürünlerin listesini almam gerekir.

        List<ShoppingCart> shoppingCarts = context.ShoppingCarts.Include(p=>p.Product).ToList();

        foreach (var cart in shoppingCarts)
        {
            try
            {
                context.Database.BeginTransaction();

                    Order order = new()
                    {
                        Price = cart.Product!.Price,
                        Quantity = cart.Quantity,
                        ProductId = cart.ProductId
                    };
                    context.Add(order);


                    Product? product = context.Products.Find(cart.ProductId);
                    if (product is not null)
                    {
                        product.Quantity -= cart.Quantity;
                        context.Update(product);

                    }

                    context.Remove(cart);
                    context.SaveChanges();

                context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                return BadRequest(ex.Message);
            }
        }
        return NoContent();
    }
}
