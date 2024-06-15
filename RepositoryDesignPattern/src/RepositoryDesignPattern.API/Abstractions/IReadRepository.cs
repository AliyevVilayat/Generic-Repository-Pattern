using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Abstractions;

public interface IReadRepository<T>:IRepository<T> where T:BaseEntity,new()
{
    IQueryable<T> GetAll();    
}
