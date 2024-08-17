using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Abstractions;

/// <summary>
/// Entity'lərin özünə xas olan bir database MANIPULATION əməliyyatı olarsa Abstraction'ı burada yer alacaq.
/// </summary>
public interface IMyEntityWriteRepository:IWriteRepository<MyEntity>
{
}
