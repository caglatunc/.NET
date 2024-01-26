using EntityFrameworkCore.RepositoryPattern.WebApi.Context;
using EntityFrameworkCore.RepositoryPattern.WebApi.DTOs;
using EntityFrameworkCore.RepositoryPattern.WebApi.Models;
using EntityFrameworkCore.RepositoryPattern.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFrameworkCore.RepositoryPattern.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ShoppingCartsController(
    ShoppingCartRepository shoppingCartRepository,
    OrderRepository orderRepository,
    AppDbContext context) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(AddShoppingCartDto request)
    {
        ShoppingCart shoppingCart = new()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity
        };

        shoppingCartRepository.Add(shoppingCart);

        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<ShoppingCart> shoppingCarts = shoppingCartRepository.GetAll();
        return Ok(shoppingCarts);
    }
    [HttpGet]
    public IActionResult CreateOrder()
    {
        List<ShoppingCart> shoppingCarts = shoppingCartRepository.GetAll();

        context.Database.BeginTransaction();
        try
        {
            foreach(var cart in shoppingCarts)
        {
                Order order = new()
                {
                    ProductId = cart.ProductId,
                    Quantity = cart.Quantity
                };
                orderRepository.Add(order);

                throw new ArgumentException("Hata!");
                shoppingCartRepository.DeleteById(cart.Id);
            }

            context.Database.CommitTransaction();
        }
        catch (Exception ex)
        {
            context.Database.RollbackTransaction();
            throw ex;
        }

        return NoContent();    
    }
}
