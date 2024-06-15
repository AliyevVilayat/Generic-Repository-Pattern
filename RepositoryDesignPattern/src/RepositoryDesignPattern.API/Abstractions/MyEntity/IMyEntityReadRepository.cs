using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Abstractions;

public interface IMyEntityReadRepository : IReadRepository<MyEntity>
{
}
