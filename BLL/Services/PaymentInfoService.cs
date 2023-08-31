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
    public class PaymentInfoService
    {
        public static List<PaymentInfoDTO> Get()
        {
            var data = DataAccess.InfoData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentInfo, PaymentInfoDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PaymentInfoDTO>>(data);
            return mapped;
        }
        public static PaymentInfoDTO Get(string id)
        {
            var data = DataAccess.InfoData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentInfo, PaymentInfoDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PaymentInfoDTO>(data);
            return mapped;
        }


        public static PaymentInfoDTO Create(PaymentInfoDTO paymentinfo)
        {


            paymentinfo.PaymentId = paymentinfo.UserId;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentInfoDTO, PaymentInfo>();
                c.CreateMap<PaymentInfo, PaymentInfoDTO>();
            });
            var mapper = new Mapper(cfg);


            var ht = mapper.Map<PaymentInfo>(paymentinfo);
            var data = DataAccess.InfoData().Create(ht);


            if (data != null)
                return mapper.Map<PaymentInfoDTO>(data);
            return null;
        }



        public static object Checkout(string userId)
        {
            return DataAccess.InfoData().Checkout(userId);
        }




        public static bool Delete(string id)
        {

            var result = DataAccess.InfoData().Delete(id);
            return result;

        }

    }
}
