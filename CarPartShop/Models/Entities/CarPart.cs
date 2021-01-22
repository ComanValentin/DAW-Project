using System;
using System.Collections.Generic;

#nullable disable

namespace CarPartShop.Models.Entities
{
    public partial class CarPart
    {
        public CarPart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public long CarPartId { get; set; }
        public string PartName { get; set; }
        public long Price { get; set; }
        public string ImageUrl { get; set; }
        public string PartDescription { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
