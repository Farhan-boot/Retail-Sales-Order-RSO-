using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Controllers
{
    public class TestController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostMultipleSimpleValues(string name) //, int value, DateTime entered, string action = null
        {
            return Json(new
            {
                name
            });
        }

        [HttpGet]
        public IHttpActionResult GetHello() //, int value, DateTime entered, string action = null
        {
            string s = "Hi";
            return Json(new
            {
                s
            });
        }
    }
}
