using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Abstractions;

public interface IMyEntityWriteRepository:IWriteRepository<MyEntity>
{
}
