using Microsoft.AspNetCore.Authentication.Cookies;
using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient(); // Web API ye baðlantý kurup api yi kullanarak veritabaný iþlemleri yapmak i.in bu servisi ekledik

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

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
