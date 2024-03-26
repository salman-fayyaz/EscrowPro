using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscrowPro.Model.Models
{
    public class Seller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int CNIC { get; set; }

        public int Phone { get; set; }

        public DateTime RegistrationDate { get; set; }

        public  ICollection<Transaction> Transactions { get; set; }

        public ICollection<Product> Products {  get; set; }
    }
}
