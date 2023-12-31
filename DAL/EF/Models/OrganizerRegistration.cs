﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OrganizerRegistration
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Conference>Conferences { get; set; }
        public OrganizerRegistration()
        {
            Conferences = new List<Conference>();
        }
    }
}
