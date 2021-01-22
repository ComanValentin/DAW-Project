using CarPartShop.Models.Entities;
using CarPartShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace CarPartShop.IRepositories
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        List<CartItem> GetAllByUserId(long userId);
        CartItem? GetById(long userId, long partId);
    }
}
