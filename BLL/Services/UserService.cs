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
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccess.UserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;
        }
        public static UserDTO Get(string id)
        {
            var data = DataAccess.UserData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }



        public static UserDTO Create(UserDTO user)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<User>(user);
            var data = DataAccess.UserData().Create(ht);


            if (data != null)
                return mapper.Map<UserDTO>(data);
            return null;
        }


        public static UserDTO Update(UserDTO userDTO)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var user = mapper.Map<User>(userDTO);
            var data = DataAccess.UserData().Update(user);
            if (data != null)
            {
                return mapper.Map<UserDTO>(data);
            }
            return null;
        }



        public static bool Delete(string id)
        {

            var result = DataAccess.UserData().Delete(id);
            return result;

        }


        public static UserTicketDTO GetwithTickets(string id)
        {
            var data = DataAccess.UserData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserTicketDTO>();
                c.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserTicketDTO>(data);
            return mapped;

        }
    }
}
