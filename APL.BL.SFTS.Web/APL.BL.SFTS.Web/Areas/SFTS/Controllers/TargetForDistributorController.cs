using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.Web.Models;
using APL.BL.SFTS.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.SFTS.Controllers
{
    public class TargetForDistributorController : Controller
    {
        // GET: SFTS/TargetForDistributor
        [SessionTimeout]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(DistributorTarget distTarget)
        {            
            // DistributorTarget objcmnParam = JsonConvert.DeserializeObject<DistributorTarget>(data[0].ToString());
            var insertedOfferId = new TargetSetupPZ().SaveOrUpdateDistributorTarget(0, distTarget.TargetItem, distTarget.TargetPeriod, 1, 1, distTarget.SetDate);

            return Json("Data Saved Successfully!");
        }
    }
}