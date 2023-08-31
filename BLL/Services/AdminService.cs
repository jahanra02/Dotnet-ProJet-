using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService
    {
        public static List<AdminDTO> Get()
        {
            var data = DataAccess.AdminData().Get();
            var mapper = MapperService<Admin, AdminDTO>.GetMapper();
            return mapper.Map<List<AdminDTO>>(data);
        }
        public static AdminDTO Get(int id)
        {
            var data = DataAccess.AdminData().Get(id);
            var mapper = MapperService<Admin, AdminDTO>.GetMapper();
            return mapper.Map<AdminDTO>(data);
        }
        public static bool Add(AdminDTO Admin)
        {
            var mapper = MapperService<AdminDTO, Admin>.GetMapper();
            var mapped = mapper.Map<Admin>(Admin);
            return DataAccess.AdminData().Create(mapped);

        }
        public static bool Update(AdminDTO Admin)
        {
            var mapper = MapperService<AdminDTO, Admin>.GetMapper();
            var mapped = mapper.Map<Admin>(Admin);
            return DataAccess.AdminData().Update(mapped);

        }
        public static bool Delete(int id)
        {

            return DataAccess.AdminData().Delete(id);

        }
    }
}
