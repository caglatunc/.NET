using EntityFrameworkCore.RepositoryPattern.WebApi.Abstractions;
using EntityFrameworkCore.RepositoryPattern.WebApi.Context;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.RepositoryPattern.WebApi.Repositories;

public class Repository<T>: IRepository<T>
    where T : Entity
{
    public readonly AppDbContext _context;
    private DbSet<T> Entity;

    public Repository(AppDbContext context)
    {
       _context = context;
        Entity = _context.Set<T>();
    }
    
    public int Add(T entity)
    {
        Entity.Add(entity);
       // _context.SaveChanges();

        return entity.Id;
    }

    public async Task<int> AddAsync(T entity)
    {
        await Entity.AddAsync(entity);
        return entity.Id;
    }

    public List<T> GetAll()
    {
        return Entity.ToList();
    }

    public void Update(T entity)
    {
        Entity.Update(entity);
       // _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        T? entity = Entity.Find(id);
        if (entity is not null)
        {
            _context.Remove(entity);
            //_context.SaveChanges();
        }
    }
}
