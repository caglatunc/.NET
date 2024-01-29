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
    IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(AddShoppingCartDto request, CancellationToken cancellationToken)
    {
        ShoppingCart shoppingCart = new()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity
        };

        await shoppingCartRepository.AddAsync(shoppingCart, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<ShoppingCart> shoppingCarts = await shoppingCartRepository.GetAllAsync();
        return Ok(shoppingCarts);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrder()
    {
        List<ShoppingCart> shoppingCarts = await shoppingCartRepository.GetAllAsync();
        foreach (var cart in shoppingCarts)
        {
            Order order = new()
            {
                ProductId = cart.ProductId,
                Quantity = cart.Quantity
            };
            orderRepository.Add(order);

           // throw new ArgumentException("Hata!");
            shoppingCartRepository.DeleteById(cart.Id);
        }
        unitOfWork.SaveChanges();

        return NoContent();    
    }
}
