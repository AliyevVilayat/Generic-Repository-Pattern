using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Context;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Concretes;

public class MyEntityWriteRepository : WriteRepository<MyEntity>,IMyEntityWriteRepository
{
    public MyEntityWriteRepository(RepositoryDesignPatternDbContext context) : base(context)
    {
    }
}
