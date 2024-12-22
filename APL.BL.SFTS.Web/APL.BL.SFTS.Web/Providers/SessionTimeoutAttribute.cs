using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Providers
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public SessionTimeoutAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                HttpContext ctx = HttpContext.Current;
                string path = filterContext.HttpContext.Request.FilePath.ToString();
                int length = path.ToString().Length;
                if (HttpContext.Current.Session["CurUserName"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Account/Login");
                    return;
                }
                if (HttpContext.Current.Session["CurUserName"] != null)
                {
                    Int64 userID = Convert.ToInt64(HttpContext.Current.Session["CurUserName"]);

                    if (length > 1)
                    {
                            HttpContext.Current.Session["CurUserName"] = null;
                            filterContext.Result = new RedirectResult("~/Account/Login");
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}
