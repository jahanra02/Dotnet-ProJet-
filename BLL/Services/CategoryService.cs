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
    public class CategoryService
    {
        public static List<CategoryDTO> Get()
        {
            var data = DataAccess.CategoryData().Get();
            var mapper = MapperService<Category, CategoryDTO>.GetMapper();
            return mapper.Map<List<CategoryDTO>>(data);
        }
        public static CategoryDTO Get(int id)
        {
            var data = DataAccess.CategoryData().Get(id);
            var mapper = MapperService<Category, CategoryDTO>.GetMapper();
            return mapper.Map<CategoryDTO>(data);
        }
        public static bool Add(CategoryDTO Category)
        {
            var mapper = MapperService<CategoryDTO, Category>.GetMapper();
            var mapped = mapper.Map<Category>(Category);
            return DataAccess.CategoryData().Create(mapped);

        }
        public static bool Update(CategoryDTO Category)
        {
            var mapper = MapperService<CategoryDTO, Category>.GetMapper();
            var mapped = mapper.Map<Category>(Category);
            return DataAccess.CategoryData().Update(mapped);

        }
        public static bool Delete(int id)
        {

            return DataAccess.CategoryData().Delete(id);

        }

        public static CategoryNoticeDTO GetWithNotice(int id)
        {
            var data = DataAccess.CategoryData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryNoticeDTO>();
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<CategoryNoticeDTO>(data);
            return cnvrted;
        }
    }
}
