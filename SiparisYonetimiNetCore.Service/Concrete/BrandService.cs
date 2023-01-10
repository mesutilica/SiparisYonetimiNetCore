using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Data.Concrete;
using SiparisYonetimiNetCore.Service.Abstract;

namespace SiparisYonetimiNetCore.Service.Concrete
{
    public class BrandService : BrandRepository, IBrandService
    {
        public BrandService(DatabaseContext context) : base(context)
        {
        }
    }
}
