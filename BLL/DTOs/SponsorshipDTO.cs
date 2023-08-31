using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SponsorshipDTO
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
        public int ConferenceId { get; set; }
    }
}
