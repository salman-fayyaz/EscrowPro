using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Dtos
{
    public class UpdateSellerFormDto
    {
        public string HouseNo { get; set; }

        public string Street { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string CountryState { get; set; }

        public string CNICSeller { get; set; }

        public Byte[] CnicImage { get; set; }

        public Byte[] KycImage { get; set; }
    }
}
