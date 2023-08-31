using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public  class TokenOrganizer
    {
        [Key]
        public int Id { get; set; }
        public string TokenKey { get; set; }
        [ForeignKey("OrganizerRegistration")]
        public int Organizer_Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public virtual OrganizerRegistration OrganizerRegistration { get; set; }

    }
}
