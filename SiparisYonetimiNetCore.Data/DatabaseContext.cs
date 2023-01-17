using Microsoft.EntityFrameworkCore;
using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // bu metot veritabanı bağlantı ayarlarını yapabildiğimiz bir metot
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=SiparisYonetimiNetCore; integrated security=True"); // connection string i yazıyoruz
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // aşağıdaki HasData metodu veritabanı oluştuktan sonra admin kullanıcısı oluşturmamızı sağlıyor(seed)
            modelBuilder.Entity<User>().HasData(new User
            {
                CreateDate = DateTime.Now,
                Email = "admin@SiparisYonetimi.net",
                Id = 1,
                IsActive = true,
                IsAdmin = true,
                Name = "Admin",
                Surname = "User",
                Username = "Admin",
                Password = "123",
                Phone = "123"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
