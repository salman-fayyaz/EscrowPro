using EscrowPro.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace EscrowPro.Core.Dtos
{
    public class BuyerUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(25)]
        [Display(Name = "Buyer Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression("^[0-9]{5}-[-|]-[0-9]{7}-[-|]-[0-9]{1}ErrorMessage = \"CNIC No must follow the XXXXX-XXXXXXX-X format!")]
        public int CNIC { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public int Phone { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
