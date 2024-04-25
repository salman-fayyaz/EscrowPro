using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscrowPro.Core.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(100)]    
        public string Description {  get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive value")]
        public int Price {  get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive value")]
        public int Quantity {  get; set; }

        public Transaction Transaction { get; set; }

        public Buyer Buyer { get; set; }

        public Seller Seller { get; set; }

    }
}
