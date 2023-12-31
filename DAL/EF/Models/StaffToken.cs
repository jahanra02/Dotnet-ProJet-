﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class StaffToken
    {
        public int Id { get; set; }
        public string TokenKey { get; set; }
        [ForeignKey("Login")]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public virtual StaffLogin Login { get; set; }
    }
}
