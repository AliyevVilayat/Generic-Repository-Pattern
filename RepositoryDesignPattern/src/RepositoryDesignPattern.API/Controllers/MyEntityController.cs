using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MyEntityController : ControllerBase
{
    private readonly IMyEntityReadRepository _myEntityReadRepository;

    public MyEntityController(IMyEntityReadRepository myEntityReadRepository)
    {
        _myEntityReadRepository = myEntityReadRepository;
    }

    [HttpGet]
    public async Task<List<MyEntity>> GetAllMyEntities()
    {
        List<MyEntity> myEntities = await _myEntityReadRepository.GetAll().ToListAsync();
        return myEntities;
    }
}
