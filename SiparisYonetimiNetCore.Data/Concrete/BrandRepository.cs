using Microsoft.EntityFrameworkCore;
using SiparisYonetimiNetCore.Data.Abstract;
using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.Data.Concrete
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Brand> GetBrandByProducts(int id)
        {
            return await _dbSet.Where(c => c.Id == id).AsNoTracking().Include(p => p.Products).FirstOrDefaultAsync();
        }
    }
}
