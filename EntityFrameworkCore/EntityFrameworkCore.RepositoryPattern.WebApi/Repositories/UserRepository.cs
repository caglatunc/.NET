using EntityFrameworkCore.RepositoryPattern.WebApi.Context;
using EntityFrameworkCore.RepositoryPattern.WebApi.Models;

namespace EntityFrameworkCore.RepositoryPattern.WebApi.Repositories;

public sealed class UserRepository : Repository<User>
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
