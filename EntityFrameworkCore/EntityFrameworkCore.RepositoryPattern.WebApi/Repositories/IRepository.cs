﻿using EntityFrameworkCore.RepositoryPattern.WebApi.Abstractions;

namespace EntityFrameworkCore.RepositoryPattern.WebApi.Repositories;

public interface IRepository<T>
    where T : Entity
{
    Task<int> AddAsync(T entity);
    int Add(T entity);
    List<T> GetAll();
    void Update(T entity);
    void DeleteById(int id);
}
