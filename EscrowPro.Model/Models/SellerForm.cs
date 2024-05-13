using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Models
{
    public class SellerForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "House number is required")]
        public string House { get; set; }

        [Required(ErrorMessage = "Street number is required")]
        public string street { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }

        [Required(ErrorMessage = "Area is required")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string CompleteAddress { get; set; }

        [Required(ErrorMessage = "Nationality is required")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        public byte[] ProfilePicture { get; set; }

        public byte[] IDCardImage { get; set; }

        public byte[] KYC { get; set; }

        public int SellerId { get; set; }

        public Seller seller { get; set; }
    }
}
