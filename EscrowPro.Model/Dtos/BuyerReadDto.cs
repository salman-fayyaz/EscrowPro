using EscrowPro.Core.Models;
using EscrowPro.Core.Models;
using System;

namespace EscrowPro.Core.Dtos
{
    public class BuyerReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CNIC { get; set; }

        public string Phone { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
