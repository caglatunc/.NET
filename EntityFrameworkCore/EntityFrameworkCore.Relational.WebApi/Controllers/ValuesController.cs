using EntityFrameworkCore.Relational.WebApi.Context;
using EntityFrameworkCore.Relational.WebApi.DTOs;
using EntityFrameworkCore.Relational.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        //List<Product>products=
        //    _context.Products
        //    .Include(p=>p.AdditionalProduct)
        //    .ToList();

        List<Product> products = (from p in _context.Products
                                  join ad in _context.AdditionalProducts on p.Id equals ad.ProductId
                                  join c in _context.Categories on p.CategoryId equals c.Id
                                  select new Product()
                                  {
                                      Id = p.Id,
                                      AdditionalProduct = ad,
                                      CategoryId = p.CategoryId,
                                      Category = c,
                                      Name = p.Name
                                  }).ToList();

        //Bu şekilde özelleştrilmiş obje halinede getirebiliriz.
        //var products = (from p in _context.Products
        //                          join ad in _context.AdditionalProducts on p.Id equals ad.ProductId
        //                          join c in _context.Categories on p.CategoryId equals c.Id
        //                          select new
        //                          {
        //                             Id = p.Id,
        //                             Name = p.Name,
        //                             Description = ad.Description,
        //                             Price= ad.Price,
        //                             CategoryName = c.Name,
                                      
        //                          }).ToList();

        return Ok(products);

    }
}
