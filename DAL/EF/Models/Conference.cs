using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Conference
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        
        public virtual OrganizerRegistration OrganizerRegistration { get; set; } 

        [ForeignKey("OrganizerRegistration")]
        public int OId { get; set; }
        [ForeignKey("Venue")]
        public int VId { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Sponsorship> Sponsorships { get; set; }
    }
}
