using EntityFrameworkCore.RepositoryPattern.WebApi.Abstractions;

namespace EntityFrameworkCore.RepositoryPattern.WebApi.Repositories;

public interface IRepository<T>
    where T : Entity
{
    Task<int> AddAsync(T entity, CancellationToken cancellationToken = default);
    int Add(T entity);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    void Update(T entity);
    void DeleteById(int id);
}
