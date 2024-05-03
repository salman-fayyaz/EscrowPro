using EscrowPro.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscrowPro.Core.Dtos
{
    public class CreateProductDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        //public Transaction Transaction { get; set; }

        [Required(ErrorMessage = "Buyer ID is required")]
        public int BuyerId { get; set; }

        public CreateBuyerDto Buyer { get; set; }

        [Required(ErrorMessage = "Seller ID is required")]
        public int SellerId { get; set; }

        public CreateSellerDto CreateSeller { get; set; }

        public string Token { get; set; }

    }
}
