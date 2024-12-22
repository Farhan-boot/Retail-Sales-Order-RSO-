using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
	public class getAdhocReport
	{
		
		public List<GET_ADHOCREPORT> GETADHOCREPORT { get; set; }
		public decimal status_code { get; set; }

	}

	public class GET_ADHOCREPORT
    {
		public Decimal ID { get; set; }
		public String REPORTNAME { get; set; }
		public Decimal REPORTTYPE { get; set; }
		public String ISMONTHEND { get; set; }
		public String UPLOADDATE { get; set; }
		public List<SP_GET_ADHOC_REPORT_DETAILS> REPORT_DETAILS { get; set; }
       
    }
}
