using EntityFrameworkCore.RepositoryPattern.WebApi.Context;
using EntityFrameworkCore.RepositoryPattern.WebApi.Models;
namespace EntityFrameworkCore.RepositoryPattern.WebApi.Repositories;

public sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context): base(context)
    {
    }
}
