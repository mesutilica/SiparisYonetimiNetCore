using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.Data.Abstract
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<Brand> GetBrandByProducts(int id);
    }
}
