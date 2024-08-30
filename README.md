# Generic Repository Pattern

Günümüzdə bir çox dataya əsaslanan tətbiqlər, verilənlər bazasında yerləşən məlumatlara əlçatan olmalıdır. Ən asan və sadə üsul, verilənlər bazasında yerləşən məlumatlarla həyata keçirilən əməliyyatların hamısını əsas kodlarla birlikdə yazmaqdır.

Məsələn, hər hansısa ASP.NET MVC layihəsində controller varsa (Employee controller deyək), burada tipik CRUD (Create, Read, Update, Delete) əməliyyatlarını həyata keçirən action’ların mövcud olduğunu fərz edək. Həmçinin, verilənlər bazası ilə əlaqəli bütün bu proseslər üçün Entity Framework istifadə etdiyimizi fərz edək. Bu zaman Entity Framework birbaşa olaraq DbContext class’ı ilə əlaqəyə girir, məlumat almaq və ya ötürmək üçün sorğular həyata keçirir. Entity Framework təməldə SQL Server verilənlər bazası ilə “danışır”.

## LinkedIn

[Vilayat Aliyev](https://www.linkedin.com/in/vilayataliyev/)









