using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.Service.Concrete;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// a�a��daki kod include yapt���m�zda ��kan json sorununu ��z�yor
builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Servisler
builder.Services.AddTransient(typeof(ICategoryService), typeof(CategoryService)); // Repository s�n�f�n� servis olarak kullanabilmek i�in
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient<IBrandService, BrandService>();
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
