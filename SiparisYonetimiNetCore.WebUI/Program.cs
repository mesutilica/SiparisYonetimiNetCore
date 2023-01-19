using Microsoft.AspNetCore.Authentication.Cookies; // Admin giriþi için gerekli kütüphane
using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // DatabaseContext dosyasýný bu þekilde servis olarak projeye ekliyoruz
// Authentication : Oturum açma - giriþ yapma iþlemi
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // admin giriþ adresimiz budur dedik
    x.Cookie.Name = "Administrator"; // oluþacak kukinin adý
});

// Authorization : giriþ yapan kullanýcýnýn nelere yetkisi var?
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin")); // Admin kullanýcý yetkisi
    options.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", "User")); //
});
// Container
builder.Services.AddTransient(typeof(ICategoryService), typeof(CategoryService)); // Repository sýnýfýný servis olarak kullanabilmek için
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient<IBrandService, BrandService>(); // servis eklemek için diðer yazým tarzý
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // View sayfalarýnda giriþ yapan kullanýcý bilgileri vb ye eriþebilmemizi saðlar.

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

app.UseAuthentication(); // önce UseAuthentication(kullanýcý giriþi)
app.UseAuthorization(); // sonra UseAuthorization(yetkilendirme)

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
