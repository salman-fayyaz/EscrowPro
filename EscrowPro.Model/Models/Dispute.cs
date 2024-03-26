using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscrowPro.Model.Models
{
    public class Dispute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

        public int TransactionId { get; set; }

        public Transaction Transaction { get; set; }


    }
}
