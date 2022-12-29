using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Data.Abstract;
using SiparisYonetimiNetCore.Data.Concrete;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // DatabaseContext dosyasýný bu þekilde servis olarak projeye ekliyoruz
// Container
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>)); // Repository sýnýfýný servis olarak kullanabilmek için
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));

//builder.Services.AddScoped
//builder.Services.AddSingleton

//Diðer Dependency Injection yöntemleri :

// AddSingleton : Uygulama ayaða kalkarken çalýþan ConfigureServices metodunda bu yöntem ile tanýmladýðýmýz her sýnýftan sadece bir örnek oluþturulur. Kim nereden çaðýrýrsa çaðýrsýn kendisine bu örnek gönderilir. Uygulama yeniden baþlayana kadar yenisi üretilmez.
// AddTransient : Uygulama çalýþma zamanýnda belirli koþullarda üretilir veya varolan örneði kullanýr. 
// AddScoped : Uygulama çalýþýrken her istek için ayrý ayrý nesne üretilir.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
