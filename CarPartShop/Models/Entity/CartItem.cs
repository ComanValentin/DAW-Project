using System;
using System.Collections.Generic;

#nullable disable

namespace CarPartShop.Models.Entity
{
    public partial class CartItem
    {
        public long UserId { get; set; }
        public long CarPartId { get; set; }
        public long Quantity { get; set; }

        public virtual CarPart CarPart { get; set; }
        public virtual User User { get; set; }
    }
}
