using System.Collections.Generic;
using System.Linq;
using CarPartShop.IRepositories;
using Microsoft.EntityFrameworkCore;
using CarPartShop.Models.Entities;
using CarPartShop.Models;
#nullable enable

namespace CarPartShop.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(CarPartShopContext context) : base(context)
        {

        }
        public List<CartItem> GetAllByUserId(long userId)
        {
            return _table.AsNoTracking()
                .Where(i => i.UserId == userId)
                .Include(i => i.CarPart)
                .ToList();
        }
        public CartItem? GetById(long userId, long carPartId)
        {
            return _table.Find(userId, carPartId);
        }
    }
}