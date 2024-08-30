# Generic Repository Pattern

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


## LinkedIn

[Vilayat Aliyev](https://www.linkedin.com/in/vilayataliyev/)









