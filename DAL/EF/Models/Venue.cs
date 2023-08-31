using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Venue_Location { get; set; }

        [Required]
        public int Venue_Capacity { get; set; }
        public Venue()
        {
            Conferences = new List<Conference>();
            Auditoriums = new List<Auditorium>();
            Staffs = new List<Staff>();
        }
        public virtual ICollection<Auditorium> Auditoriums { get; set; }
        public virtual ICollection<Conference> Conferences { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

    }
}
