using EntityFrameworkCore.Relational.WebApi.Context;
using EntityFrameworkCore.Relational.WebApi.DTOs;
using EntityFrameworkCore.Relational.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.Relational.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class ValuesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ValuesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("Add")]
    public IActionResult Add(CreateProductDto request)
    {
       
        Product? product = _context.Products.FirstOrDefault(p => p.Name == request.ProductName);

        if(product is not null)
        {
            return BadRequest(new {Message= "Bu isimde bir ürün zaten mevcut!" });
        }

            product = new()
        {
            Id = Guid.NewGuid(),
            Name = request.ProductName,
            //CategoryId = category.Id,
        };


        AdditionalProduct additionalProduct = new()
        {
            //ProductId = product.Id,
            Description = request.ProductDescription,
            Price = request.ProductPrice,
        };

        product.AdditionalProduct = additionalProduct;

        Category category = _context.Categories.FirstOrDefault(p => p.Name == request.CategoryName);//Kategori database de kontrol ediyoruz.

        if (category is null)
        {
            category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.CategoryName,
            };
            //_context.Add(category);
            product.Category=category;
        }
        else
        {
            product.CategoryId = category.Id;
        }

        _context.Add(product);

        //_context.Add(additionalProduct);
        //_context.Add(category);
      
        _context.SaveChanges();

        return Ok(new {Id= product.Id});
    }
}
