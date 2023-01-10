using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByProducts(int id); // kategoriyi ürünleriyle birlikte asenkron getirecek olan metot imzası
    }
}
