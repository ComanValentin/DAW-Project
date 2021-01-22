using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartShop.DTO
{
    public class CartItemDTO
    {
        public long CarPartId { get; set; }
        public long Quantity { get; set; }
    }
}
