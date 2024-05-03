using System;
using System.ComponentModel.DataAnnotations;

namespace EscrowPro.Core.Dtos
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive value")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive value")]
        public int Quantity { get; set; }

        public string Token { get; set; }

        public UpdateBuyerDto UpdateBuyer { get; set; }

        public UpdateSellerDto UpdateSeller { get;set; }
    }
}
