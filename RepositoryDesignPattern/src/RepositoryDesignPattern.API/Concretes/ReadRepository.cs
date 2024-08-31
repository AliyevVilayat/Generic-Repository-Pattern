using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Context;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Concretes;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
    private RepositoryDesignPatternDbContext _context;

    public ReadRepository(RepositoryDesignPatternDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll()
    {
        var query = Table.AsQueryable();
        return query;
    }

    public async Task<T?> GetByIdAsync(Guid id, bool isTracking = false)
    {
        var query = Table.AsQueryable();
        if (!isTracking)
        {
            query.AsNoTracking();
        }
        T? entity = await query.SingleOrDefaultAsync(e=>e.Id == id);
        return entity;
    }
}
