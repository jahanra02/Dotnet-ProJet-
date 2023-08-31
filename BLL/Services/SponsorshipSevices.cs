using AutoMapper;
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
    public  class SponsorshipSevices
    {
        public static List<SponsorshipDTO> Get()
        {
            var data = DataAccess.SponsorshipData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Sponsorship, SponsorshipDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<SponsorshipDTO>>(data);
            return cnvrted;
        }

        public static SponsorshipDTO Get(int id)
        {
            var data = DataAccess.SponsorshipData().Get(id);
            var mapper = MapperService<Sponsorship, SponsorshipDTO>.GetMapper();
            return mapper.Map<SponsorshipDTO>(data);
        }
       
        public static bool Add(SponsorshipDTO post)
        {
            var mapper = MapperService<SponsorshipDTO, Sponsorship>.GetMapper();
            var mapped = mapper.Map<Sponsorship>(post);
            return DataAccess.SponsorshipData().Create(mapped);

        }

        public static bool Update(SponsorshipDTO post)
        {
            var mapper = MapperService<SponsorshipDTO, Sponsorship>.GetMapper();
            var mapped = mapper.Map<Sponsorship>(post);
            return DataAccess.SponsorshipData().Update(mapped);

        }
        public static bool Delete(int id)
        {

            return DataAccess.SponsorshipData().Delete(id);

        }


        public static List<SponsorshipDTO> GetSponsorshipsByConference(int conferenceId)
        {
            var data = (from s in DataAccess.SponsorshipData().Get()
                        where s.ConferenceId == conferenceId
                        select s).ToList();

            var mapper = MapperService<Sponsorship, SponsorshipDTO>.GetMapper();
            var converted = mapper.Map<List<SponsorshipDTO>>(data);
            return converted;
        }

        public static List<SponsorshipDTO> GetSponsorshipsBySponsor(string sponsorCompanyName)
        {
            var data = (from s in DataAccess.SponsorshipData().Get()
                        where s.SponsorCompanyName.Contains(sponsorCompanyName)
                        select s).ToList();

            var mapper = MapperService<Sponsorship, SponsorshipDTO>.GetMapper();
            var converted = mapper.Map<List<SponsorshipDTO>>(data);
            return converted;
        }

        public static SponsorshipDTO GetSponsorshipByAmountAndKeyword(decimal amount, string keyword)
        {
            var data = (from s in DataAccess.SponsorshipData().Get()
                        where s.Amount > amount && s.SponsorCompanyName.Contains(keyword)
                        orderby s.Amount descending
                        select s).FirstOrDefault();

            if (data != null)
            {
                var mapper = MapperService<Sponsorship, SponsorshipDTO>.GetMapper();
                return mapper.Map<SponsorshipDTO>(data);
            }
            else
            {
                return null; 
            }
        }
    }
}
