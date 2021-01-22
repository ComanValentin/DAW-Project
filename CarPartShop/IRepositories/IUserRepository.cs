using CarPartShop.Models.Entities;
using CarPartShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace CarPartShop.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetByEmailAndPassword(string email, string password);
        User? GetByEmail(string email);
    }
}
