using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class PaymentInfo
    {
        [Key]
        public string PaymentId { get; set; }
        public int CardNumber { get; set; }
        public string Name { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Cvv { get; set; }
        public string BillingAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int ZipCode { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
