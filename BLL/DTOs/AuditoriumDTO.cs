using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AuditoriumDTO
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string A_Name { get; set; }

        [Required]
        public int A_Capacity { get; set; }

        [Required]
        public int Venue_id { get; set; }
    }
}
