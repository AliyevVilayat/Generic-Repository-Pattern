using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Context;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Concretes;

public class MyEntityReadRepository : ReadRepository<MyEntity>, IMyEntityReadRepository
{
    public MyEntityReadRepository(RepositoryDesignPatternDbContext context) : base(context)
    {
    }
}
