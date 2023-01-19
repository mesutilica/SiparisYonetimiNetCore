using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByCategoryAndBrandAsync(int id);
        Task<List<Product>> GetProductsByCategoryAndBrandAsync();
    }
}
