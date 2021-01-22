using System;
using System.Collections.Generic;

#nullable disable

namespace CarPartShop.Models.Entities
{
    public partial class User
    {
        public User()
        {
            CartItems = new HashSet<CartItem>();
        }

        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
