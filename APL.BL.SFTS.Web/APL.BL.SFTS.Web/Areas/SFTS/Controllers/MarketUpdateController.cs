﻿using APL.BL.SFTS.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.SFTS.Controllers
{
    public class MarketUpdateController : Controller
    {
        // GET: SFTS/MarketUpdate
        [SessionTimeout]
        public ActionResult Index()
        {
            return View();
        }
    }
}