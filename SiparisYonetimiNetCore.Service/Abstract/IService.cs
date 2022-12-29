using SiparisYonetimiNetCore.Data.Abstract;
using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {
    }
}
