using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Data.Concrete;
using SiparisYonetimiNetCore.Service.Abstract;

namespace SiparisYonetimiNetCore.Service.Concrete
{
    public class CategoryService : CategoryRepository, ICategoryService
    {
        public CategoryService(DatabaseContext context) : base(context)
        {
        }
    }
}
