using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.SystemCommon
{
    public class SystemCommonAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SystemCommon";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SystemCommon_default",
                "SystemCommon/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}