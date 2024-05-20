using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Dtos
{
    public class UpdateLoginDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string status { get; set; }
    }
}
