using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
   public class GetIssuePosm
    {
        public List<Get_issue_request> data { get; set; }
        public int status_code { get; set; }
    }

	public class GetTOP5Posm
	{
		public List<SP_FF_GET_Top5POSMP_PRODUCT> data { get; set; }
		public int status_code { get; set; }
	}
}
