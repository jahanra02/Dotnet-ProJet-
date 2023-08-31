using BLL.Services;
using Conference_Ticketing_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Conference_Ticketing_System.Controllers
{

    public class StaffLoginController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(StaffLoginModel data)
        {
            var token = StaffLoginService.Login(data.Email, data.Password);
            if (token != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "User not found" });
            }


        }
    }
}
