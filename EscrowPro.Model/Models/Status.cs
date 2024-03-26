using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Model.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Level { get; set; }

        public Transaction Transaction { get; set; }

        public Escrow Escrow { get; set; }
    }
}
