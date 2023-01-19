using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Data.Concrete;
using SiparisYonetimiNetCore.Service.Abstract;

namespace SiparisYonetimiNetCore.Service.Concrete
{
    public class ProductService : ProductRepository, IProductService
    {
        public ProductService(DatabaseContext context) : base(context)
        {
        }
    }
}
