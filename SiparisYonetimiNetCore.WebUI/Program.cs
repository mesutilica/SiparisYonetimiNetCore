using Microsoft.AspNetCore.Authentication.Cookies; // Admin giri�i i�in gerekli k�t�phane
using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // DatabaseContext dosyas�n� bu �ekilde servis olarak projeye ekliyoruz
// Authentication : Oturum a�ma - giri� yapma i�lemi
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // admin giri� adresimiz budur dedik
    x.Cookie.Name = "Administrator"; // olu�acak kukinin ad�
});

// Authorization : giri� yapan kullan�c�n�n nelere yetkisi var?
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin")); // Admin kullan�c� yetkisi
    options.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", "User")); //
});
// Container
builder.Services.AddTransient(typeof(ICategoryService), typeof(CategoryService)); // Repository s�n�f�n� servis olarak kullanabilmek i�in
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient<IBrandService, BrandService>(); // servis eklemek i�in di�er yaz�m tarz�
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // View sayfalar�nda giri� yapan kullan�c� bilgileri vb ye eri�ebilmemizi sa�lar.

//builder.Services.AddScoped
//builder.Services.AddSingleton

//Di�er Dependency Injection y�ntemleri :

// AddSingleton : Uygulama aya�a kalkarken �al��an ConfigureServices metodunda bu y�ntem ile tan�mlad���m�z her s�n�ftan sadece bir �rnek olu�turulur. Kim nereden �a��r�rsa �a��rs�n kendisine bu �rnek g�nderilir. Uygulama yeniden ba�layana kadar yenisi �retilmez.
// AddTransient : Uygulama �al��ma zaman�nda belirli ko�ullarda �retilir veya varolan �rne�i kullan�r. 
// AddScoped : Uygulama �al���rken her istek i�in ayr� ayr� nesne �retilir.

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

app.UseAuthentication(); // �nce UseAuthentication(kullan�c� giri�i)
app.UseAuthorization(); // sonra UseAuthorization(yetkilendirme)

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
