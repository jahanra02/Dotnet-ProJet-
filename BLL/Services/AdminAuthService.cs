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
    public class AdminAuthService
    {
        public static AdminTokenDTO Login(string uname, string pass)
        {
            var user = DataAccess.AdminAuthData().Authenticate(uname, pass);
            if (user != null)
            {
                var token = new AdminToken();
                token.TokenKey = Guid.NewGuid().ToString();
                token.AdminId = user.Id;
                token.Username = user.Username;
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                var tk = DataAccess.AdminTokensData().Create(token);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<AdminToken, AdminTokenDTO>();
                });
                var mapper = new Mapper(config);
                var data = mapper.Map<AdminTokenDTO>(tk);
                return data;
            }
            return null;
        }
        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccess.TokensData().Get()
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

    