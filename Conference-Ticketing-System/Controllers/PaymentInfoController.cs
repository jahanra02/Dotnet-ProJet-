using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Conference_Ticketing_System.Controllers
{
    public class PaymentInfoController : ApiController
    {
        [HttpPost]
        [Route("api/paymentInfo/create")]
        public HttpResponseMessage CreatPaymentInfo(PaymentInfoDTO paymentinfo)
        {
            try
            {
                var res = PaymentInfoService.Create(paymentinfo);
                return Request.CreateResponse(HttpStatusCode.OK, " Created Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/paymentinfo/{id}")]
        public HttpResponseMessage PaymentInfo(string id)
        {
            try
            {
                var res = PaymentInfoService.Get(id);
                return Request.CreateResponse(new { paymentinfo = res });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/paymentinfo/checkout/{UserId}")]
        public HttpResponseMessage Checkout(string userId)
        {
            try
            {
                var data = PaymentInfoService.Checkout(userId);
                return Request.CreateResponse(new { data = data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/paymentinfo/delete/{id}")]
        public HttpResponseMessage DeleteCart(string id)
        {
            try
            {
                var res = PaymentInfoService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
