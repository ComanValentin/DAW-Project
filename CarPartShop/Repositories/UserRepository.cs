using CarPartShop.IRepositories;
using CarPartShop.Models;
using CarPartShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace CarPartShop.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(CarPartShopContext context): base(context)
        {

        }
        public User? GetByEmailAndPassword(string email, string password)
        {
            return _table.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
        public User? GetByEmail(string email)
        {
            return _table.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
