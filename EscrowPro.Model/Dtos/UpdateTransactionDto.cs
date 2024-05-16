using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Dtos
{
    public class UpdateTransactionDto
    {
        public int Amount { get; set; }

        public string Description { get; set; }

        public int? BuyerId { get; set; }

        public int? SellerId { get; set; }

        public int? ProductId { get; set; }

        public int? StatusId { get; set; }
    }
}
