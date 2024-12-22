using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.Models.SFTS;
using APL.BL.SFTS.ProcessZone;
using APL.BL.SFTS.Web.Providers;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace APL.BL.SFTS.Web.Areas.SFTS.Controllers
{
    public class TargetSetupController : Controller
    {
        // GET: SFTS/DistributorTarget
        [SessionTimeout]
        public ActionResult Index()
        {
            return View();
        }

        #region Export Excel

        public ActionResult ExportFile()
        {
            List<string> cities = new List<string>();
            cities.Add("New York");
            cities.Add("Mumbai");
            cities.Add("Berlin");
            cities.Add("Istanbul");

            var v = cities;


            var gv = new GridView { DataSource = v };
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename= TestFile.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }

        #endregion

    }
}