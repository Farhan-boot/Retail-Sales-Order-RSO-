using System.Web.Mvc;
using System.Web.Http;

namespace APL.BL.SFTS.Web.Areas.VFOCUS
{
    public class VFocusAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "VFOCUS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
			
			context.Routes.MapHttpRoute(
					name: "VFocusAPIAction",
					routeTemplate: "VFocusAPI/api/{controller}/{action}",
					defaults: new { id = RouteParameter.Optional }
				);

			context.Routes.MapHttpRoute(
				   name: "VFocusAPI",
				   routeTemplate: "VFocusAPI/api/{controller}",
				   defaults: new { id = RouteParameter.Optional }
			   );



			context.MapRoute(
				"VFocus_default",
				"VFocus/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);


			/*
			context.Routes.MapHttpRoute(
					 name: "VFOCUSApiAction",
					 routeTemplate: "VFOCUS/api/{controller}/{action}",
					 defaults: new { id = RouteParameter.Optional }
				 );

			context.Routes.MapHttpRoute(
				   name: "VFOCUSApi",
				   routeTemplate: "VFOCUS/api/{controller}",
				   defaults: new { id = RouteParameter.Optional }
			   );

			context.MapRoute(
				"VFOCUSs_default",
				"VFOCUS/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);  */
		}
    }
}