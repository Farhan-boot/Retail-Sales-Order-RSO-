using APL.BL.SFTS.DataBridgeZone.SP_Class;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Retailer
{
    public class AdhocReportDZ
    {
        public AdhocReportDZ()
        { }


        public List<SP_GET_ADHOC_REPORT> GetAdhocReports(decimal USERID)
        {
            try
            {
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;


				OracleParameter USERID_OP = new OracleParameter();
				USERID_OP.Direction = System.Data.ParameterDirection.Input;
				USERID_OP.OracleDbType = OracleDbType.Decimal;
				USERID_OP.Value = USERID;


				return (List<SP_GET_ADHOC_REPORT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ADHOC_REPORT>.GetDataBySP(new SP_GET_ADHOC_REPORT(), "SP_FF_GET_ADHOC_REPORT", 36, resultOutCurSor, USERID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<SP_GET_ADHOC_REPORT_DETAILS> GetAdhocReportsDetails(Decimal reportID, Decimal userID)
		{
			try
			{
				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				OracleParameter reportID_OP = new OracleParameter();
				reportID_OP.Direction = System.Data.ParameterDirection.Input;
				reportID_OP.OracleDbType = OracleDbType.Decimal;
				reportID_OP.Value = reportID;

				OracleParameter userID_OP = new OracleParameter();
				userID_OP.Direction = System.Data.ParameterDirection.Input;
				userID_OP.OracleDbType = OracleDbType.Decimal;
				userID_OP.Value = userID;

				return (List<SP_GET_ADHOC_REPORT_DETAILS>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ADHOC_REPORT_DETAILS>.GetDataBySP(new SP_GET_ADHOC_REPORT_DETAILS(), "SP_FF_GET_ADHOC_REPORT_DETAILS", 36, resultOutCurSor, reportID_OP, userID_OP);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
