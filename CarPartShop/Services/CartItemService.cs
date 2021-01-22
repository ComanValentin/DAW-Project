using AutoMapper;
using CarPartShop.IRepositories;
using CarPartShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartShop.Services
{
    public class CartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;
        private readonly ICarPartRepository _carPartRepository;
        public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper, ICarPartRepository carPartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _carPartRepository = carPartRepository;
            _mapper = mapper;
        }
        public List<CartItem> GetAllItemsForUser(User user)
        {
            return _cartItemRepository.GetAllByUserId(user.UserId);
        }
        public List<CartItem> AddCartItemForUser(User user, long cartPartId)
        {
            if (_carPartRepository.GetById(cartPartId) == null) throw new KeyNotFoundException();

            var cartItem = _cartItemRepository.GetById(user.UserId, cartPartId);
            if (cartItem == null)
            {
                _cartItemRepository.Create(new CartItem
                {
                    UserId = user.UserId,
                    CarPartId = cartPartId,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity++;
                _cartItemRepository.Update(cartItem);
            }

            _cartItemRepository.SaveChanges();
            return GetAllItemsForUser(user);
        }
        public List<CartItem> UpdateCartItemQuantity(User user, long cartPartId, long quantity)
        {
            var cartItem = _cartItemRepository.GetById(user.UserId, cartPartId);
            if (cartItem == null)
                throw new KeyNotFoundException("Part not found");

            if (quantity <= 0) throw new ArgumentException("Invalid Quantity");

            cartItem.Quantity = quantity;
            _cartItemRepository.Update(cartItem);
            _cartItemRepository.SaveChanges();

            return GetAllItemsForUser(user);
        }
        public List<CartItem> RemoveCartItemForUser(User user, long quantity)
        {
            var cartItem = _cartItemRepository.GetById(user.UserId, quantity);
            if (cartItem == null)
                throw new KeyNotFoundException("Part not found");
            _cartItemRepository.HardDelete(cartItem);
            _cartItemRepository.SaveChanges();

            return GetAllItemsForUser(user);
        }

    }
}
