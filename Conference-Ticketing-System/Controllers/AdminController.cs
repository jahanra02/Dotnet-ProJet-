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
    
        [RoutePrefix("api/admin")]

        public class AdminController : ApiController
        {
            [HttpGet]
            [Route("all")]
            public HttpResponseMessage Get()
            {
                try
                {
                    var data = AdminService.Get();
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
                    var data = AdminService.Get(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }
            [HttpPost]
            [Route("create")]
            public HttpResponseMessage Add(AdminDTO obj)
            {
                try
                {
                    var data = AdminService.Add(obj);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }
            [HttpPut]
            [Route("update")]
            public HttpResponseMessage Update(AdminDTO obj)
            {
                try
                {
                    var data = AdminService.Update(obj);
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
                    var data = AdminService.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }

        }
    }
