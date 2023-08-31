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
    public class ConferenceReviewService
    {
        public static ConferenceReviewDTO Create(ConferenceReviewDTO conferencereview)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ConferenceReviewDTO, ConferenceReview>();
                c.CreateMap<ConferenceReview, ConferenceReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<ConferenceReview>(conferencereview);
            var data = DataAccess.ReviewData().Create(ht);


            if (data != null)
                return mapper.Map<ConferenceReviewDTO>(data);
            return null;
        }

        public static ConferenceReviewDTO Update(ConferenceReviewDTO ConferencereviewDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ConferenceReviewDTO, ConferenceReview>();
                c.CreateMap<ConferenceReview, ConferenceReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var conferencereview =
                mapper.Map<ConferenceReview>(ConferencereviewDTO);
            var data = DataAccess.ReviewData().Update(conferencereview);
            if (data != null)
            {
                return mapper.Map<ConferenceReviewDTO>(data);
            }
            return null;
        }

        public static bool Delete(string id)
        {

            var result = DataAccess.ReviewData().Delete(id);
            return result;

        }

        public static List<ConferenceReviewDTO> Get()
        {
            var data = DataAccess.ReviewData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ConferenceReview, ConferenceReviewDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ConferenceReviewDTO>>(data);
            return mapped;
        }
        public static ConferenceReviewDTO Get(string id)
        {
            var data = DataAccess.ReviewData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ConferenceReview, ConferenceReviewDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ConferenceReviewDTO>(data);
            return mapped;
        }
    }
}
