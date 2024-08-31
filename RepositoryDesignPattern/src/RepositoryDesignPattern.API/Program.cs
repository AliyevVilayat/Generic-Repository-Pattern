using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API;
using RepositoryDesignPattern.API.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string _connectionStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<RepositoryDesignPatternDbContext>(opt =>
{
    opt.UseSqlServer(_connectionStr);
});

builder.Services.RegisterServices();

var app = builder.Build();

await app.AddSeeder();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
