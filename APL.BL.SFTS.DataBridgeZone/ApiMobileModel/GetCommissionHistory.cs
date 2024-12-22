using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
   public class GetCommissionHistory
    {
       public List<GET_COMMISSION_HISTORY> data { get; set; }
       public int status_code { get; set; }
    }


	public class GetCommissionSummary
	{
		public List<SP_GET_RSO_COMMISSION_SUMMSRY> data { get; set; }
		public int status_code { get; set; }
	}

	public class GetCommissionDetails
	{
		public List<SP_GET_RSO_COMMISSION_DETAILS> data { get; set; }
		public int status_code { get; set; }
	}


	public class GetRsoEarning
	{
		public List<SP_GET_FF_RSO_EARNING> data { get; set; }
		public int status_code { get; set; }
	}

	public class GetCommissionPeriod
	{
		public List<SP_GET_TARGET_PERIOD> data { get; set; }
		public int status_code { get; set; }
	}
}
