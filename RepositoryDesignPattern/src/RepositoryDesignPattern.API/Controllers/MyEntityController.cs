using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Context;
using RepositoryDesignPattern.API.Entities;
using System;

namespace RepositoryDesignPattern.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MyEntityController : ControllerBase
{
    private readonly RepositoryDesignPatternDbContext _context;

    private readonly IReadRepository<MyEntity> _readRepository;
    private readonly IWriteRepository<MyEntity> _writeRepository;

    private readonly IMyEntityReadRepository _myEntityReadRepository;
    private readonly IMyEntityWriteRepository _myEntityWriteRepository;

    public MyEntityController(RepositoryDesignPatternDbContext context, IReadRepository<MyEntity> readRepository, IWriteRepository<MyEntity> writeRepository, IMyEntityReadRepository myEntityReadRepository, IMyEntityWriteRepository myEntityWriteRepository)
    {
        _context = context;

        _readRepository = readRepository;
        _writeRepository = writeRepository;

        _myEntityReadRepository = myEntityReadRepository;
        _myEntityWriteRepository = myEntityWriteRepository;
    }

    #region WithOutRepositoryPattern

    /*[HttpPost]
    public async Task<IActionResult> CreateMyEntity(MyEntity myEntity)
    {
        await _context.MyEntities.AddAsync(myEntity);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<List<MyEntity>> GetAllMyEntities()
    {
        List<MyEntity> myEntities = await _context.MyEntities.ToListAsync();
        return myEntities;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMyEntity(string id, MyEntity myEntity)
    {
        Guid guid = new(id);
        MyEntity? baseEntity = _context.MyEntities.AsNoTracking().SingleOrDefault(e=>e.Id == guid);
        if (baseEntity == null) throw new Exception("Entity not found in Database");

        baseEntity.Name = myEntity.Name;
        baseEntity.Description = myEntity.Description;
        baseEntity.Status = myEntity.Status;
        baseEntity.CreatedDate = myEntity.CreatedDate;
        baseEntity.LastModifiedDate = myEntity.LastModifiedDate;
        baseEntity.DeletedDate = myEntity.DeletedDate;

        _context.MyEntities.Update(baseEntity);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMyEntity(string id)
    {
        Guid guid = new(id);
        MyEntity? baseEntity = _context.MyEntities.Find(guid);
        if (baseEntity == null) throw new Exception("Entity not found in Database"); 

        _context.MyEntities.Remove(baseEntity);
        await _context.SaveChangesAsync();
        return Ok();
    }*/

    #endregion

    #region WithRepositoryPattern

    [HttpPost]
    public async Task<IActionResult> CreateMyEntity(MyEntity myEntity)
    {
        await _writeRepository.CreateAsync(myEntity);
        await _writeRepository.SaveAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<List<MyEntity>> GetAllMyEntities()
    {
        List<MyEntity> myEntities = await _readRepository.GetAll().ToListAsync();
        return myEntities;
    }


    [HttpPut]
    public async Task<IActionResult> UpdateMyEntity(string id, MyEntity myEntity)
    {
        Guid guid = new(id);
        MyEntity? baseEntity = await _readRepository.GetByIdAsync(guid);
        if (baseEntity == null) throw new Exception("Entity not found in Database");

        baseEntity.Name = myEntity.Name;
        baseEntity.Description = myEntity.Description;
        baseEntity.Status = myEntity.Status;
        baseEntity.CreatedDate = myEntity.CreatedDate;
        baseEntity.LastModifiedDate = myEntity.LastModifiedDate;
        baseEntity.DeletedDate = myEntity.DeletedDate;

        _writeRepository.Update(baseEntity);
        await _writeRepository.SaveAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMyEntity(string id)
    {
        Guid guid = new(id);
        MyEntity? baseEntity = await _readRepository.GetByIdAsync(guid);
        if (baseEntity == null) throw new Exception("Entity not found in Database");

        _writeRepository.Remove(baseEntity);
        await _writeRepository.SaveAsync();
        return Ok();

    }
    #endregion

    #region WithRepositoryPatternWithCustomRepositoryClasses
/*
    [HttpPost]
    public async Task<IActionResult> CreateMyEntity(MyEntity myEntity)
    {
        await _myEntityWriteRepository.CreateAsync(myEntity);
        await _myEntityWriteRepository.SaveAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<List<MyEntity>> GetAllMyEntities()
    {
        List<MyEntity> myEntities = await _myEntityReadRepository.GetAll().ToListAsync();
        return myEntities;
    }


    [HttpPut]
    public async Task<IActionResult> UpdateMyEntity(string id, MyEntity myEntity)
    {
        Guid guid = new(id);
        MyEntity? baseEntity = await _myEntityReadRepository.GetByIdAsync(guid);
        if (baseEntity == null) throw new Exception("Entity not found in Database");

        baseEntity.Name = myEntity.Name;
        baseEntity.Description = myEntity.Description;
        baseEntity.Status = myEntity.Status;
        baseEntity.CreatedDate = myEntity.CreatedDate;
        baseEntity.LastModifiedDate = myEntity.LastModifiedDate;
        baseEntity.DeletedDate = myEntity.DeletedDate;

        _myEntityWriteRepository.Update(baseEntity);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMyEntity(string id)
    {
        Guid guid = new(id);
        MyEntity? baseEntity = await _myEntityReadRepository.GetByIdAsync(guid);
        if (baseEntity == null) throw new Exception("Entity not found in Database");

        _myEntityWriteRepository.Remove(baseEntity);
        await _context.SaveChangesAsync();
        return Ok();

    }*/
    #endregion

}
