using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryNoticeDTO
    {
        public List<NoticeDTO> Notices { get; set; }
        public CategoryNoticeDTO()
        {
            Notices = new List<NoticeDTO>();
        }
    }
}
