﻿using APL.BL.SFTS.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.SFTSReports.Controllers
{
    public class RetailerSalesController : Controller
    {
        // GET: SFTSReports/RetailerSales
        [SessionTimeout]
        public ActionResult Index()
        {
            return View();
        }
    }
}