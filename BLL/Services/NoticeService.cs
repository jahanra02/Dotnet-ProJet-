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
    public class NoticeService
    {
        public static List<NoticeDTO> Get()
        {
            var data = DataAccess.NoticeData().Get();
            var mapper = MapperService<Notice, NoticeDTO>.GetMapper();
            return mapper.Map<List<NoticeDTO>>(data);
        }
        public static NoticeDTO Get(int id)
        {
            var data = DataAccess.NoticeData().Get(id);
            var mapper = MapperService<Notice, NoticeDTO>.GetMapper();
            return mapper.Map<NoticeDTO>(data);
        }
        public static bool Add(NoticeDTO Notice)
        {
            var mapper = MapperService<NoticeDTO, Notice>.GetMapper();
            var mapped = mapper.Map<Notice>(Notice);
            return DataAccess.NoticeData().Create(mapped);

        }
        public static bool Update(NoticeDTO Notice)
        {
            var mapper = MapperService<NoticeDTO, Notice>.GetMapper();
            var mapped = mapper.Map<Notice>(Notice);
            return DataAccess.NoticeData().Update(mapped);

        }
        public static bool Delete(int id)
        {

            return DataAccess.NoticeData().Delete(id);

        }

        public static List<NoticeDTO> Get(DateTime date)
        {
            var data = (from n in DataAccess.NoticeData().Get()
                        where n.Date.Date == date
                        select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<NoticeDTO>>(data);
            return cnvrted;

        }
        public static List<NoticeDTO> Get(string cat)
        {
            var data = (from n in DataAccess.NoticeData().Get()
                        where n.Category.Name.ToLower().Contains(cat.ToLower())
                        select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<NoticeDTO>>(data);
            return cnvrted;

        }
        public static List<NoticeDTO> Get(string cat, DateTime date)
        {
            var data = (from n in DataAccess.NoticeData().Get()
                        where n.Category.Name.ToLower().Contains(cat.ToLower())
                        && n.Date.Date == date
                        select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<NoticeDTO>>(data);
            return cnvrted;
        }

    }
}
