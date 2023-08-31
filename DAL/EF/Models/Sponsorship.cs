using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Sponsorship
    {
            [Key]
            public int Id { get; set; }

            [Required]
            public string SponsorCompanyName { get; set; }

            [Required]
            public string ContactEmail { get; set; }

            [Required]
            public string ContactPhone { get; set; }

            [Required]
            public decimal Amount { get; set; }

            [ForeignKey("Conference")]
            public int ConferenceId { get; set; }
            public virtual Conference Conference { get; set; }
        
    }

}

