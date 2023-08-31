﻿using AutoMapper;
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
    public class UserAuthService
    {
        public static UserTokenDTO Authenticate(string uname, string pass)
        {

            var res = DataAccess.UserAuthData().Authenticate(uname, pass);
            if (res)
            {
                var token = new UserToken();
                token.UserId = uname;
                token.CreatedTime = DateTime.Now;

                DateTime time1 = DateTime.Now;
                DateTime time2 = time1.AddMinutes(20);
                token.ExpiredTime = time2;

                token.TKey = Guid.NewGuid().ToString();
                var ret = DataAccess.UserTokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<UserToken, UserTokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<UserTokenDTO>(ret);
                }

            }
            return null;
        }
        public static bool IsTokenValid(string tkey)
        {
            var extk = DataAccess.UserTokenData().Read(tkey);
            if (extk != null && extk.ExpiredTime > DateTime.Now)
            {
                return true;
            }
            return false;
        }


        public static bool Logout(string tkey)
        {
            var extk = DataAccess.UserTokenData().Read(tkey);
            extk.ExpiredTime = DateTime.Now;
            if (DataAccess.UserTokenData().Update(extk) != null)
            {
                return true;
            }
            return false;


        }

    }

}
