using EntityFrameworkCore.RepositoryPattern.WebApi.Abstractions;
using EntityFrameworkCore.RepositoryPattern.WebApi.Context;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.RepositoryPattern.WebApi.Repositories;

public class Repository<T>: IRepository<T>
    where T : Entity
{
    public readonly AppDbContext context;

    public Repository(AppDbContext context)
    {
        this.context = context;
    }
    
    public int Add(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();

        return entity.Id;
    }

    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        T? entity = context.Set<T>().Find(id);
        if (entity is not null)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

    }
}
