using ClassStructures.WebAPI.DTOs;
using ClassStructures.WebAPI.Models;
using ClassStructures.WebAPI.Utilities;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ClassStructures.WebAPI.Services;

public class ProductService
{
    public static List<Product> products = new();
    public Result<List<Product>> GetAll()
    {
        return products;
    }
    public Result<Guid> Add(AddProductDto request) 
    {
        Product product = new(
            name:request.Name,
            quantity: request.Quantity,
            price:request.Price);

        products.Add(product);
        return "Product addition process successful!";
    }

    public Result<Guid> Selling(Guid productId, int quantity)
    {
        Product? product = products.FirstOrDefault(p=>p.Id == productId);
        if (product is null)
        {
            return (500, "The product could not be found!");
        }

        product.Quantity -= quantity;

        if(product.Quantity < 0)
        {
           product.Quantity += quantity;
            string errorMessage = product.Name + " The product stock will decrease into negative after the sale, so the sale has been canceled. Please add stock and proceed with the sale again!";
          
            return (500, errorMessage);
        }

        return "The product sale process was successful!";
    }
    public Result<Guid> AddStock(Guid productId, int quantity)
    {
        Product? product = products.FirstOrDefault(p => p.Id == productId);
        if (product is null)
        {
            return (500, "The product could not be found!");
        }

        product.Quantity += quantity;
        return "The product quantity was successfully updated!";
    }
    public Result<List<ProductReportListDto>> GetProductListForReport()
    {
       var reportList= products.Select(s => new ProductReportListDto
        {
            ProductName = s.Name,
            ProductQuantity = s.Quantity
        }).ToList();

       return reportList;
    }

}
