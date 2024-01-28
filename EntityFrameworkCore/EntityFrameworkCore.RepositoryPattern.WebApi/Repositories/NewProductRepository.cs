using EntityFrameworkCore.RepositoryPattern.WebApi.Models;

namespace EntityFrameworkCore.RepositoryPattern.WebApi.Repositories;

public class NewProductRepository : IProductRepository
{
    public int Add(Product entity)
    {
        //MongoDB kayıt kodları
        return entity.Id;
    }

    public void DeleteById(int id)
    {
        //MongoDb remove kodları
       
    }

    public List<Product> GetAll()
    {
        //MongoDbList Kodları
        return new List<Product>();
    }

    public int SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity)
    {
        //MongoDb Update kodları
    }
    public int SaveCahnges()
    {
        return 0;
    }

    public Task<int> AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }
}
