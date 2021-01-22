using System.Collections.Generic;
#nullable enable

namespace CarPartShop.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T entity);
        void CreateRange(IEnumerable<T> entities);
        void HardDelete(T entity);
        T? GetById(long id);
        List<T> GetAll();
        bool SaveChanges();
        void Update(T entity);
    }
}