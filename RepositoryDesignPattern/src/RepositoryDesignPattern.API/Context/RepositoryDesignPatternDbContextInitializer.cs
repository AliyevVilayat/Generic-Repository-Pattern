using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Context;

public class RepositoryDesignPatternDbContextInitializer
{
    private RepositoryDesignPatternDbContext _context;

    public RepositoryDesignPatternDbContextInitializer(RepositoryDesignPatternDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        await _context.Database.MigrateAsync();
    }

    public async Task CreateMyEntities()
    {
        if (_context.MyEntities.Count() == 0)
        {
            List<MyEntity> myEntities = new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "MyEntityName1",
                    Description = "MyEntityDescription1",
                    CreatedDate = DateTime.Now,
                    Status = Enums.Status.Active,
                    
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "MyEntityName2",
                    Description = "MyEntityDescription2",
                    CreatedDate = DateTime.Now,
                    Status = Enums.Status.Inactive,

                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "MyEntityName3",
                    Description = "MyEntityDescription3",
                    CreatedDate = DateTime.Now,
                    Status = Enums.Status.Active,

                },


            };
            await _context.MyEntities.AddRangeAsync(myEntities);
            await _context.SaveChangesAsync();
        }
    }

}
