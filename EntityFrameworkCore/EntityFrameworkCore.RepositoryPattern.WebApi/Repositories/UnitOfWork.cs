using EntityFrameworkCore.RepositoryPattern.WebApi.Context;

namespace EntityFrameworkCore.RepositoryPattern.WebApi.Repositories;

public sealed class UnitOfWork(AppDbContext context)
{
    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}
