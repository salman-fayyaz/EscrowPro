using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscrowPro.Core.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Level { get; set; }

        public Transaction Transaction { get; set; }

        public Escrow Escrow { get; set; }
    }
}
