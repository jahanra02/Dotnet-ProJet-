using BLL.DTOs;
using DAL.EF.Models;
using DAL.EF;
using DAL.Repos;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StaffService
    {
        public static List<StaffDTO> Get()
        {
            var data = DataAccess.StaffData().Get();
            var mapper = MapperService<Staff, StaffDTO>.GetMapper();
            return mapper.Map<List<StaffDTO>>(data);
        }
        public static StaffDTO Get(int id)
        {
            var data = DataAccess.StaffData().Get(id);
            var mapper = MapperService<Staff, StaffDTO>.GetMapper();
            return mapper.Map<StaffDTO>(data);
        }
        public static bool Add(StaffDTO Staff)
        {
            var mapper = MapperService<StaffDTO, Staff>.GetMapper();
            var mapped = mapper.Map<Staff>(Staff);
            return DataAccess.StaffData().Create(mapped);

        }
        public static bool Update(StaffDTO Staff)
        {
            var mapper = MapperService<StaffDTO, Staff>.GetMapper();
            var mapped = mapper.Map<Staff>(Staff);
            return DataAccess.StaffData().Update(mapped);

        }
        public static bool Delete(int id)
        {

            return DataAccess.StaffData().Delete(id);

        }
    }
}

    
