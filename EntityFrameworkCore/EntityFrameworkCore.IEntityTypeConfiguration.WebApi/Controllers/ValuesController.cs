using Bogus;
using Bogus.DataSets;
using EntityFrameworkCore.IEntityTypeConfiguration.WebApi.Context;
using EntityFrameworkCore.IEntityTypeConfiguration.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.IEntityTypeConfiguration.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController(AppDbContext context) : ControllerBase
{
    private static List<Product> Products = new();

    [HttpGet]
    public IActionResult Get()
    {
        Product product = new()
        {
            Id = Ulid.NewUlid().ToString(),
            Name = "Yeni Kayıt" + Products.Count,
            CreatedDate = DateTime.UtcNow
        };

        Products.Add(product);
        return Ok(Products);
    }

    [HttpGet]
    public IActionResult Sort(bool reverse)
    {
        if (reverse)
        {
            return Ok(Products.OrderByDescending(p => p.Id));
        }
        else
        {
            return Ok(Products.OrderBy(p => p.Id));
        }
    }

    [HttpGet]
    public IActionResult SeedData()
    {
        List<Category> categories = new();
        for (int i = 0; i < 5; i++)
        {
            List<Product> products = new();
            for (int j=0; j<10; j++)
            {
                Faker fakerProduct = new();
                bool isProductNameUnique = false;
                string productName = "";
                while (!isProductNameUnique)
                {
                    productName = fakerProduct.Random.AlphaNumeric(30);
                    if (!products.Any(product => product.Name == productName))
                    {
                        isProductNameUnique = true;
                    }
                }
          
                Product product = new()
                {
                    Name = productName,
                    CreatedDate = DateTime.Now
                };
                products.Add(product);
            }

            Faker faker = new();

            bool isCategoryNameUnique = false;
            string categoryName = "";
            while (!isCategoryNameUnique)
            {
               categoryName = faker.Vehicle.Manufacturer();
                if (!categories.Any(category => category.Name == categoryName))
                {
                    isCategoryNameUnique = true;
                }
            }

            Category category = new()
            {
                Name = categoryName,
                CreatedDate = DateTime.Now,
                //Products = products
              
            };
            categories.Add(category);
        }
       context.AddRange(categories);
       context.SaveChanges();

        return NoContent();
    }

    [HttpGet]

    public IActionResult GetAllProduct()
    {
        //Product listesini kategori ile beraber çekmek istiyoruz.
        //Bu yüzden Include ile kategori bilgisini çekiyoruz.

        List<Product> products = context.Set<Product>().Include(p => p.Category).ToList();

        //var products =
        //    context.Set<Product>()
        //    .Include(p => p.Category)
        //    .Select(s => new
        //    {
        //        Id = s.Id,
        //        Name = s.Name,
        //        CreatedDate = s.CreatedDate,
        //        CategoryName = s.Category!.Name
        //    })
        //    .ToList();

        //List<Product> products = (from product in context.Set<Product>().ToList()
        //                          join category in context.Set<Category>() on product.CategoryId equals category.Id
        //                          select new Product()
        //                          {
        //                              Id = product.Id,
        //                              Name = product.Name,
        //                              CreatedDate = product.CreatedDate,
        //                              Category = category,
        //                              CategoryId = category.Id
        //                          }).ToList();


        //string query = @"
        //select 
        //    [p].[Id], [p].[Name], [p].[CreatedDate], [c].[Name] AS [CategoryName] 
        //from Products as p
        //inner join Categories as c on p.CategoryId = c.Id";

        //var products =
        //    context.Set<Product>().FromSqlRaw("Select * from Products").ToList();


        return Ok(products);

    }
}
