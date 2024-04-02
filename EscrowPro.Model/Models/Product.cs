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

        public string Name { get; set; }

        public string Description {  get; set; }

        public int Price {  get; set; }

        public int Quantity {  get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public Buyer Buyer { get; set; }

        public Seller Seller { get; set; }

    }
}
