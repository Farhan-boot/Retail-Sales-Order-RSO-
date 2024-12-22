using APL.BL.SFTS.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.SFTS.Controllers
{
    public class ApproveDistributorTargetReviseController : Controller
    {
        // GET: SFTS/ApproveDistributorTargetRevise
        [SessionTimeout]
        public ActionResult Index()
        {
            return View();
        }
    }
}