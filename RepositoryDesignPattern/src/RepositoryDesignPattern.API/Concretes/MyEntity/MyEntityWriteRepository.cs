using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Context;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Concretes;

/// <summary>
/// Entity'lərin özünə xas olan bir database MANIPULATION əməliyyatı olarsa Concrete'i burada yer alacaq.
/// </summary>
public class MyEntityWriteRepository : WriteRepository<MyEntity>,IMyEntityWriteRepository
{
    public MyEntityWriteRepository(RepositoryDesignPatternDbContext context) : base(context)
    {
    }
}
