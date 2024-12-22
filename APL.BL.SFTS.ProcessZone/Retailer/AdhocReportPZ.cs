using APL.BL.SFTS.DataBridgeZone.Retailer;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Retailer
{
    public class AdhocReportPZ
    {
        public AdhocReportPZ() { }

        public List<SP_GET_ADHOC_REPORT> GetAdhocReports(Decimal USERID)
        {
            try
            {
                return new AdhocReportDZ().GetAdhocReports(USERID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<SP_GET_ADHOC_REPORT_DETAILS> GetAdhocReportsDetails(Decimal reportID, Decimal userid)
		{
			try
			{
				return new AdhocReportDZ().GetAdhocReportsDetails(reportID, userid);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
