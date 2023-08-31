using BLL.DTOs;
using BLL.Services;
using Conference_Ticketing_System.AuthFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace Conference_Ticketing_System.Controllers
{
        [RoutePrefix("api/staff")]
        public class StaffController : ApiController
        {
            [AdminLogged]
            [HttpGet]
            [Route("all")]
            public HttpResponseMessage Get()
            {
                try
                {
                    var data = StaffService.Get();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }
            [HttpGet]
            [Route("get/{id}")]
            public HttpResponseMessage Get(int id)
            {
                try
                {
                    var data = StaffService.Get(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }
            [HttpPost]
            [Route("create")]
            public HttpResponseMessage Add(StaffDTO obj)
            {
                try
                {
                    var data = StaffService.Add(obj);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }
            [HttpPut]
            [Route("update")]
            public HttpResponseMessage Update(StaffDTO obj)
            {
                try
                {
                    var data = StaffService.Update(obj);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }
            [HttpDelete]
            [Route("delete/{id}")]
            public HttpResponseMessage Delete(int id)
            {
                try
                {
                    var data = StaffService.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }
        }
}

