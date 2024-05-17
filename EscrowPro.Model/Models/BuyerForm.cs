using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Core.Models
{
    public class BuyerForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="House number is required")]
        public string HouseNo {  get; set; }

        [Required(ErrorMessage ="Street number is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Area is required")]
        public string Area { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage ="Country is required")]
        public string CountryState { get; set; }

        [Required(ErrorMessage ="CNIC Number is required")]
        public string CNICBuyer { get; set; }

        [Required(ErrorMessage = "CNIC Image")]
        public Byte[] CnicImage { get; set; }

        [Required(ErrorMessage = "KYC Image is required")]
        public Byte[] KycImage { get; set; }

    }
}
