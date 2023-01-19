using Microsoft.EntityFrameworkCore;
using SiparisYonetimiNetCore.Data.Abstract;
using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.Data.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<Product> GetProductByCategoryAndBrandAsync(int id)
        {
            return _context.Products.Include(c => c.Category).Include(b => b.Brand).FirstOrDefaultAsync(p=>p.Id == id);
        }

        public Task<List<Product>> GetProductsByCategoryAndBrandAsync()
        {
            return _context.Products.Include(c => c.Category).Include(b => b.Brand).ToListAsync();
        }
    }
}
