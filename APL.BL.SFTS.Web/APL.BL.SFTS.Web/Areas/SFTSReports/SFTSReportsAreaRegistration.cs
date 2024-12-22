using System.Web.Http;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.SFTSReports
{
    public class SFTSReportsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SFTSReports";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapHttpRoute(
                name: "SFTSReportsAction",
                routeTemplate: "SFTSReports/api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );

            context.Routes.MapHttpRoute(
                   name: "SFTSReports",
                   routeTemplate: "SFTSReports/api/{controller}",
                   defaults: new { id = RouteParameter.Optional }
               );

            context.MapRoute(
                "SFTSReports_default",
                "SFTSReports/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}