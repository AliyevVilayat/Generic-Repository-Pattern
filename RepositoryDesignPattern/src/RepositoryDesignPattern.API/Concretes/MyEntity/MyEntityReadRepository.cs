using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Context;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Concretes;

/// <summary>
/// Entity'lərin özünə xas olan bir database SELECT əməliyyatı olarsa Concrete'i burada yer alacaq.
/// </summary>
public class MyEntityReadRepository : ReadRepository<MyEntity>, IMyEntityReadRepository
{
    public MyEntityReadRepository(RepositoryDesignPatternDbContext context) : base(context)
    {
    }
}
