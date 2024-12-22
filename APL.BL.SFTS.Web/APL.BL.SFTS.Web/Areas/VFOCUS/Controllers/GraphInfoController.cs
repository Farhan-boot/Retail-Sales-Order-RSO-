using APL.BL.SFTS.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.VFOCUS.Controllers
{
    public class GraphInfoController : Controller
    {
        [SessionTimeout]
        // GET: VFocus/GraphInfo
        public ActionResult Index()
        {
            return View();
        }
    }
}