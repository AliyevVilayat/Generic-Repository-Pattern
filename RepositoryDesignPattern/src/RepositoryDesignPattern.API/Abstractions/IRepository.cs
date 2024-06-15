using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API.Entities;
using System.Runtime.InteropServices;

namespace RepositoryDesignPattern.API.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
}
