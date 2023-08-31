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
    public class SponsorshipController : ApiController
    {
        [HttpGet]
        [Route("all/Sponsorship")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = SponsorshipSevices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("get/Sponsorship/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = SponsorshipSevices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("create/Sponsorship")]
        public HttpResponseMessage Add(SponsorshipDTO obj)
        {
            try
            {
                var data = SponsorshipSevices.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPut]
        [Route("update/Sponsorship")]
        public HttpResponseMessage Update(SponsorshipDTO obj)
        {
            try
            {
                var data = SponsorshipSevices.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/Sponsorship/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = SponsorshipSevices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("sponsorshipsByConference/{conferenceId}")]
        public HttpResponseMessage GetSponsorshipsByConference(int conferenceId)
        {
            try
            {
                var data = SponsorshipSevices.GetSponsorshipsByConference(conferenceId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("sponsorshipsBySponsor/{sponsorCompanyName}")]
        public HttpResponseMessage GetSponsorshipsBySponsor(string sponsorCompanyName)
        {
            try
            {
                var data = SponsorshipSevices.GetSponsorshipsBySponsor(sponsorCompanyName);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        //New///new//new//new

        [HttpGet]
        [Route("getSponsorshipsByAmountAndKeyword/{amount}/{keyword}")]
        public HttpResponseMessage GetSponsorshipsByAmountAndKeyword(decimal amount, string keyword)
        {
            try
            {
                var data = SponsorshipSevices.GetSponsorshipByAmountAndKeyword(amount, keyword);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

    }
}
