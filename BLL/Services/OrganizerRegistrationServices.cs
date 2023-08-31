using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrganizerRegistrationServices
    {
        public static List<OrganizerRegistrationDTO> Get()
        {
            var data = DataAccess.OrganizerRegistrationData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrganizerRegistration, OrganizerRegistrationDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<OrganizerRegistrationDTO>>(data);
            return cnvrted;
        }
        public static OrganizerRegistrationDTO Get(int id)
        {
            var data = DataAccess.OrganizerRegistrationData().Get(id);
            var mapper = MapperService<OrganizerRegistration, OrganizerRegistrationDTO>.GetMapper();
            return mapper.Map<OrganizerRegistrationDTO>(data);
        }

        public static bool Add(OrganizerRegistrationDTO post)
        {
            var mapper = MapperService<OrganizerRegistrationDTO, OrganizerRegistration>.GetMapper();
            var mapped = mapper.Map<OrganizerRegistration>(post);
            return DataAccess.OrganizerRegistrationData().Create(mapped);

        }
        public static bool Update(OrganizerRegistrationDTO post)
        {
            var mapper = MapperService<OrganizerRegistrationDTO, OrganizerRegistration>.GetMapper();
            var mapped = mapper.Map<OrganizerRegistration>(post);
            return DataAccess.OrganizerRegistrationData().Update(mapped);

        }
        public static bool Delete(int id)
        {

            return DataAccess.OrganizerRegistrationData().Delete(id);

        }
    }
}
