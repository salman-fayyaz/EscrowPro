using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Model.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime StartDate {  get; set; }

        public DateTime CompletionDate { get; set; }

        public int BuyerId { get; set; }

        public Buyer Buyer { get; set; }

        public int SellerId {  get; set; }

        public Seller Seller { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public Escrow Escrow { get; set; }

        public Payment Payment { get;set; }

        public Dispute Dispute { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

    }
}
