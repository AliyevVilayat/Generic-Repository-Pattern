using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Abstractions;

/// <summary>
/// Entity'lərin özünə xas olan bir database SELECT əməliyyatı olarsa Abstraction'ı burada yer alacaq.
/// </summary>
public interface IMyEntityReadRepository : IReadRepository<MyEntity>
{
}
