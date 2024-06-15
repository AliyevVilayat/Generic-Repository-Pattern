using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Context;

public class RepositoryDesignPatternDbContext:DbContext
{
    public RepositoryDesignPatternDbContext(DbContextOptions<RepositoryDesignPatternDbContext> options):base(options:options)
    {
        
    }

    public DbSet<MyEntity> MyEntities { get; set; } = null!;
}
