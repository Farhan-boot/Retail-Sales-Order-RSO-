using System;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;

namespace APL.BL.SFTS.Web.Areas.SFTS
{
    public class SFTSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SFTS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
			string message = "";

			message = "API CALL Start Rute";
			WriteServiceLog(message);

			try
			{
				context.Routes.MapHttpRoute(
					 name: "SFTSApiAction",
					 routeTemplate: "SFTS/api/{controller}/{action}",
					 defaults: new { id = RouteParameter.Optional }
				 );

				context.Routes.MapHttpRoute(
					   name: "SFTSApi",
					   routeTemplate: "SFTS/api/{controller}",
					   defaults: new { id = RouteParameter.Optional }
				   );

				context.MapRoute(
					"SFTSs_default",
					"SFTS/{controller}/{action}/{id}",
					new { action = "Index", id = UrlParameter.Optional }
				);
			}
			catch (System.Exception e)
			{

				e.ToString();

				message = "ERROR Rute: " + e.Message.ToString();
				WriteServiceLog(message);
			}

			message = "API CALL END Rute";
			WriteServiceLog(message);


		}


		public static void WriteServiceLog(string logMessage)
		{
			TextWriter w;
			w = OpenServiceLogFile();
			w.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
			w.Write(" :");
			w.Write($" {logMessage}");
			w.WriteLine(";");
			w.Close();
		}

		private static System.IO.TextWriter OpenServiceLogFile()
		{
			String strlogFileLocation;

			strlogFileLocation = System.Configuration.ConfigurationManager.AppSettings.Get("LogFileLocation");
			// ConfigurationSettings.AppSettings.Get("LogFileLocation");

			if (!System.IO.Directory.Exists(strlogFileLocation))
			{
				System.IO.Directory.CreateDirectory(strlogFileLocation);
			}

			string filepath = strlogFileLocation + "\\Servicelog_" + DateTime.Now.ToString("dd_MMM_yyyy") + ".txt";

			if (!File.Exists(filepath))
			{
				// Create a file to write to.   
				return File.CreateText(filepath);
			}
			else
			{
				return File.AppendText(filepath);
			}
		}
	}
}