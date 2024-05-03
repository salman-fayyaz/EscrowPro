using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Dtos
{
    public class ReadEscrowDto
    {
        public DateTime FundedDate { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
