using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Context;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Concretes;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{

    private RepositoryDesignPatternDbContext _context;

    public WriteRepository(RepositoryDesignPatternDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
    }
    public void Update(T entity)
    {
        Table.Update(entity);
    }

    public void Remove(T entity)
    {
        Table.Remove(entity);
    }

    public async Task SaveAsync(T entity)
    {
        await _context.SaveChangesAsync();
    }

}
