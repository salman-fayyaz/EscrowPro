using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Dtos
{
    public class ReadTransactionDto
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }
    }
}
