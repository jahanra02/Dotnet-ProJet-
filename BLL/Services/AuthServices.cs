using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthServices
    {
        public static TokenDTO Login(string name, string password)
        {
            var user = DataAccess.AuthDataAccess().Authenticate(name, password);
            if (user != null)
            {
                var token = new TokenOrganizer();
                token.Organizer_Id = user.Id;
                token.TokenKey = Guid.NewGuid().ToString();
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                var tk = DataAccess.TokenOrganizerData().Create(token);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<TokenOrganizer, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var data = mapper.Map<TokenDTO>(tk);
                return data;
            }
            return null;
        }
        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccess.TokenOrganizerData().Get()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t).SingleOrDefault();
            if (tk != null)
            {
                return true;
            }
            return false;
        }

        
    }
}
