﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SeatDTO
    {
        public int Id { get; set; }

        [Required]
        public string Row { get; set; }
        [Required]
        public bool Type { get; set; }
        public int Auditorium_id { get; set; }
    }
}
