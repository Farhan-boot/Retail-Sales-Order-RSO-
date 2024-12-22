using System.Web.Http;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.SFTSApi
{
    public class SFTSApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SFTSApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                    name: "SFTSMobileApiAction",
                    routeTemplate: "SFTSApi/api/{controller}/{action}",
                    defaults: new { id = RouteParameter.Optional }
                );

            context.Routes.MapHttpRoute(
                   name: "SFTSMobileApi",
                   routeTemplate: "SFTSApi/api/{controller}",
                   defaults: new { id = RouteParameter.Optional }
               );

            context.MapRoute(
                "SFTSMobile_default",
                "SFTSApi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}