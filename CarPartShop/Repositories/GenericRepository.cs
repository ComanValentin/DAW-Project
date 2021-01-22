using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPartShop.Models;
using Microsoft.EntityFrameworkCore;

#nullable enable

namespace CarPartShop.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CarPartShopContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(CarPartShopContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Create(T entity)
        {
            _table.Add(entity);
        }

        public void CreateRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
        }

        public void HardDelete(T entity)
        {
            _table.Remove(entity);
        }

        public T? GetById(long id)
        {
            return _table.Find(id);
        }
        public List<T> GetAll()
        {
            return _table.ToList();
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}
