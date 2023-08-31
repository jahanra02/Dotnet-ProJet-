using BLL.DTOs;
using BLL.Services;
using Conference_Ticketing_System.AuthFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Conference_Ticketing_System.Controllers
{
    
    public class OrganizerRegistrationController : ApiController
    {

        [HttpGet]
        [Route("all/Organizer")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = OrganizerRegistrationServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpGet]
        [Route("get/Organizer/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = OrganizerRegistrationServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("create/Organizer")]
        public HttpResponseMessage Add(OrganizerRegistrationDTO obj)
        {
            try
            {
                var data = OrganizerRegistrationServices.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPut]
        [Route("update/Organizer")]
        public HttpResponseMessage Update(OrganizerRegistrationDTO obj)
        {
            try
            {
                var data = OrganizerRegistrationServices.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpDelete]
        [Route("delete/Organizer/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = OrganizerRegistrationServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

    }
}
