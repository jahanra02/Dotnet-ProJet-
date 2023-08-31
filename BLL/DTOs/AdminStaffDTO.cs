using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdminStaffDTO : AdminDTO
    {
        public List<StaffDTO> Staffs { get; set; }
        public AdminStaffDTO()
        {
            Staffs = new List<StaffDTO>();
        }
    }
}
