using System;
using System.ComponentModel.DataAnnotations;

namespace EscrowPro.Core.Dtos
{
    public class UpdateProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public byte[]? ProductImage { get; set; }

        public int? SellerId { get; set; }
    }
}
