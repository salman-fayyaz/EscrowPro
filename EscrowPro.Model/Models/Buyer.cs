using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscrowPro.Core.Models
{
    public class Buyer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(25)]
        [Display(Name="Buyer Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email {  get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password {  get; set; }
        
        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match..")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression("^[0-9]{5}-[-|]-[0-9]{7}-[-|]-[0-9]{1}ErrorMessage = \"CNIC No must follow the XXXXX-XXXXXXX-X format!")]
        public int CNIC { get; set; }

        [Required(ErrorMessage ="Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public int Phone { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
