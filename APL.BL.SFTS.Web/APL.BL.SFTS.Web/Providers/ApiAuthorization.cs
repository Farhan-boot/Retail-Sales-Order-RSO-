using APL.BL.SFTS.ProcessZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace APL.BL.SFTS.Web.Providers
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
	public class ApiAuthorization : AuthorizationFilterAttribute
	{
		private const string _authorizedToken = "AuthorizedToken";
		private const string _userAgent = "User-Agent";

		// private UserAuthorizations objAuth = null;

		public override void OnAuthorization(HttpActionContext filterContext)
		{
			string authorizedToken = string.Empty;
			string userAgent = string.Empty;

			try
			{
				var headerToken = filterContext.Request.Headers.SingleOrDefault(x => x.Key == _authorizedToken);
				if (headerToken.Key != null)
				{
					authorizedToken = Convert.ToString(headerToken.Value.SingleOrDefault());
					userAgent = Convert.ToString(filterContext.Request.Headers.UserAgent);
					if (!IsAuthorize(authorizedToken, userAgent))
					{
						filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
						return;
					}
				}
				else
				{
					filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
					return;
				}
			}
			catch (Exception)
			{
				filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
				return;
			}

			base.OnAuthorization(filterContext);
		}


		private bool IsAuthorize(string authorizedToken, string userAgent)
		{
			bool result = false;
			try
			{
				result = new GenerateTokenPZ().ValidateWebToken(authorizedToken, userAgent);
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}