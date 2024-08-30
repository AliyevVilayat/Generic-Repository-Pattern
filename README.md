## Generic Repository Pattern

Günümüzdə bir çox dataya əsaslanan tətbiqlər, verilənlər bazasında yerləşən məlumatlara əlçatan olmalıdır. 

Ən asan və sadə üsul, verilənlər bazasında yerləşən məlumatlarla həyata keçirilən əməliyyatların hamısını əsas kodlarla birlikdə yazmaqdır.
```csharp
[Route("api/[controller]")]
[ApiController]
public class MyEntitiesController : ControllerBase
{
    private readonly RepositoryDesignPatternDbContext _context;

    public MyEntityController(RepositoryDesignPatternDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<MyEntity>> GetAllMyEntities()
    {
        List<MyEntity> myEntities = await _context.MyEntities.ToListAsync();
        return myEntities;
    }
}
```

Məsələn, hər hansısa `ASP.NET API` layihəsində controller varsa (MyEntities controller deyək), burada tipik CRUD (Create, Read, Update, Delete) əməliyyatlarını həyata keçirən action-ların mövcud olduğunu fərz edək. 
Həmçinin, verilənlər bazası ilə əlaqəli bütün bu proseslər üçün Entity Framework Core istifadə etdiyimizi fərz edək. Bu zaman Entity Framework Core birbaşa olaraq DbContext class-ı ilə əlaqəyə girir, məlumat almaq və ya ötürmək üçün sorğular həyata keçirir. Entity Framework Core təməldə SQL Server verilənlər bazası ilə “danışır”.

```Repository Design Pattern```, interface istifadə edərək `Abstraction` tətbiq edib, Data Access Layer ilə Business Logic Layer-i bir-birindən ayırmaq və onların arasında vasitəçi və ya orta təbəqə (layer) rolunu təmin etmək üçün istifadə edilən memari design pattern’dir. Bu o deməkdir ki, Repository Pattern verilənlər bazası ilə bağlı olan kodları proyektin qalan hissəsindən təcrid edir. Bu Design Pattern-in bizə qazandırdığı ən böyük üstünlük verilənlər bazası ilə bağlı olan əməliyyatların hamısını bir yerdən idarə edə bilməkdir. 

Başqa bir faydası isə controller’ləri daha rahat test edə bilməkdir. Lakin Repository pattern `SOLID` prinsiplərindən S, yəni `Single Responsibility` prinsipini pozur. Çünki həm data çəkmək, həm də data göndərib onun üzərində hər hansısa bir iş görmək üçün olan method-lar eyni class daxilində yerləşir. SOLID prinsipini pozmaq istəmiriksə, `Read` və `Write` olaraq Repository-ni iki yerə bölmək lazımdır.

## Repository Pattern’in Tətbiqi

Repository Pattern’i tətbiq etmək üçün, əgər Onion (Clean) Architecture istifadə ediriksə, Application folder daxilində Interface Repository’lərin saxlanılması üçün Abstractions və onun da daxilində Repositories adlı bir folder yaradılır. Bu qovluqda IRepository, IReadRepository və IWriteRepository interfeysləri yerləşdirilir.

IRepository interfeysində DbSet tipində Table property yer alır.
```csharp
public interface IRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
}
```
IReadRepository interfeysində oxuma (read) ilə bağlı get method-lar yerləşir.
```csharp
public interface IReadRepository<T>:IRepository<T> where T:BaseEntity,new()
{
    IQueryable<T> GetAll();    
}
```


IWriteRepository interfeysində isə Create, Update və Delete üçün lazım olan method’lar və SaveChanges method’u yer alır.
```csharp
public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task SaveAsync(T entity);
}
```

Bu interfeyslərin konkretləri yəni Concrete class-ları isə Persistence layer-də, Concretes folder və onun da daxilində Repositories adlı başqa bir folder-də yer alır. 

`ReadRepository` class’ı IReadRepository interfeysini implement etməlidir.
```csharp
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
}
```

`WriteRepository` class’ı isə IWriteRepository interfeysini implement etməlidir.
```csharp

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
```

Lakin IRepository interfeysinin konkret bir class’ı olmamalıdır.

Folder Structure aşağıdaki şəkildə olur.

![image](https://github.com/user-attachments/assets/b394e572-e0c8-41b4-bb90-03f861d83647)

![image](https://github.com/user-attachments/assets/dc2d7fde-e2cb-4620-b877-bef0f19788e7)






## LinkedIn

[Vilayat Aliyev](https://www.linkedin.com/in/vilayataliyev/)









