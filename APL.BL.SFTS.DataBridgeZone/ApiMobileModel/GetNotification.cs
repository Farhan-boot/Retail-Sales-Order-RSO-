using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
	public class GetNotification
	{
		public List<SP_GET_NOTIFICATIONS> data { get; set; }
		public int status_code { get; set; }
	}


	public class Notificationparam
	{
		public int USERID { get; set; }
		public int RETAILERID { get; set; }
		public int ID { get; set; }		
		public int TYPE { get; set; }		
		public String FROM_DATE { get; set; }		
		public String TO_DATE { get; set; }
	}
}
