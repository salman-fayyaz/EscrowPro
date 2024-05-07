using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Dtos
{
    public class CreateTransactionDto
    {
        public int Amount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }
    }
}
