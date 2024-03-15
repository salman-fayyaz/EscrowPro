using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Model.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime StartDate {  get; set; }

        public DateTime CompletionDate { get; set; }

        public int BuyerId { get; set; }

        public Buyer Buyer { get; set; }

        public int SellerId {  get; set; }

        public Seller Seller { get; set; }
    }
}
