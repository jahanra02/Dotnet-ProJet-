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
    public class ConferenceController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("all/Conference")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ConferenceServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("all/Conference/WithVenue")]
        public HttpResponseMessage GetWithVenue()
        {
            try
            {
                var data = ConferenceServices.GetWithVenue();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("get/Conference/{id}")]
        public HttpResponseMessage Get(DateTime id)
        {
            try
            {
                var data = ConferenceServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("create/Conference")]
        public HttpResponseMessage Add(ConferenceDTO obj)
        {
            try
            {
                var data = ConferenceServices.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            } 
        }
        [HttpPut]
        [Route("update/Conference/{id}")]
        public HttpResponseMessage Update(ConferenceDTO obj)
        {
            try
            {
                var data = ConferenceServices.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpDelete]
        [Route("delete/Conference/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = ConferenceServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        //Newly Added
        [HttpGet]
        [Route("conferencesByTopic/{topic}")]
        public HttpResponseMessage GetConferencesByTopic(string topic)
        {
            try
            {
                var data = ConferenceServices.GetConferencesByTopic(topic);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        //Ajke
        [HttpGet]
        [Route("api/upcomingConferences")]
        public HttpResponseMessage GetUpcomingConferences()
        {
            try
            {
                var data = ConferenceServices.GetUpcomingConferences();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpGet]
        [Route("searchConferences/{keyword}")]
        public HttpResponseMessage SearchConferences(string keyword)
        {
            try
            {
                var data = ConferenceServices.SearchConferences(keyword);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }




    }
}
