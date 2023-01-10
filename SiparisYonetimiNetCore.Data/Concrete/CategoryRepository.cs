using Microsoft.EntityFrameworkCore;
using SiparisYonetimiNetCore.Data.Abstract;
using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.Data.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByProducts(int id)
        {
            return await _dbSet.Where(c => c.Id == id).AsNoTracking().Include(p => p.Products).FirstOrDefaultAsync();
        }
    }
}
