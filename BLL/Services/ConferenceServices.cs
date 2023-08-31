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
    public class ConferenceServices
    {
        public static List<ConferenceDTO> Get()
        {
            var data = DataAccess.ConferenceData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Conference, ConferenceDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<ConferenceDTO>>(data);
            return cnvrted;
        }
        public static List<ConferenceDTO> Get(DateTime date)
        {
            var data = (from n in DataAccess.ConferenceData().Get()
                        where n.Date.Date == date
                        select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Conference, ConferenceDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<ConferenceDTO>>(data);
            return cnvrted;

        }

        public static bool Add(ConferenceDTO post)
        {
            var mapper = MapperService<ConferenceDTO, Conference>.GetMapper();
            var mapped = mapper.Map<Conference>(post);
            return DataAccess.ConferenceData().Create(mapped);

        }

        public static bool Update(ConferenceDTO post)
        {
            var mapper = MapperService<ConferenceDTO, Conference>.GetMapper();
            var mapped = mapper.Map<Conference>(post);
            return DataAccess.ConferenceData().Update(mapped);

        }
        public static bool Delete(int id)
        {

            return DataAccess.ConferenceData().Delete(id);

        }
        public static List<ConferenceWithVenueDTO> GetWithVenue()
        {
            var data = DataAccess.ConferenceData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Conference, ConferenceWithVenueDTO>()
                .ForMember(dst=>dst.VenueName,opt=>opt.MapFrom(src=>src.Venue.Name));
                //cfg.CreateMap<Venue, VenueDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<ConferenceWithVenueDTO>>(data);
            return cnvrted;
        }

        //Newly Added
        public static List<ConferenceDTO> GetConferencesByTopic(string topic)
        {
            var data = (from n in DataAccess.ConferenceData().Get()
                        where n.Topic.Equals(topic, StringComparison.OrdinalIgnoreCase)
                        select n).ToList();

            var mapper = MapperService<Conference, ConferenceDTO>.GetMapper();
            var converted = mapper.Map<List<ConferenceDTO>>(data);
            return converted;
        }

        public static List<ConferenceDTO> GetUpcomingConferences()
        {
            var currentDate = DateTime.UtcNow.Date;
            var data = (from n in DataAccess.ConferenceData().Get()
                        where n.Date >= currentDate
                        orderby n.Date
                        select n).ToList();

            var mapper = MapperService<Conference, ConferenceDTO>.GetMapper();
            var converted = mapper.Map<List<ConferenceDTO>>(data);
            return converted;
        }

        public static List<ConferenceDTO> SearchConferences(string keyword)
        {
            var data = (from n in DataAccess.ConferenceData().Get()
                        where n.Details.Contains(keyword) || n.Topic.Contains(keyword)
                        select n).ToList();

            var mapper = MapperService<Conference, ConferenceDTO>.GetMapper();
            var converted = mapper.Map<List<ConferenceDTO>>(data);
            return converted;
        }
    }
}
