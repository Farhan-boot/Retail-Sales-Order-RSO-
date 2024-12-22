using APL.BL.SFTS.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.SFTSReports.Controllers
{
    public class RetailerStockController : Controller
    {
        // GET: SFTSReports/RetailerStock
        [SessionTimeout]
        public ActionResult Index()
        {
            return View();
        }
    }
}