using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.RSO
{
    public class RSOPointDZ
    {
        public RSOPointDZ()
        { }

        public List<SP_GET_RSOPOINT_WEB> GetRSOPoints(SearchParam searchParam)//decimal zoneId, string fromDate, decimal appID, decimal userId)
        {
            try
            {
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                OracleParameter zoneId_OP = new OracleParameter();
                zoneId_OP.Direction = System.Data.ParameterDirection.Input;
                zoneId_OP.OracleDbType = OracleDbType.Decimal;
                zoneId_OP.Value = searchParam.ZoneId;


                OracleParameter AppId_OP = new OracleParameter();
                AppId_OP.Direction = System.Data.ParameterDirection.Input;
                AppId_OP.OracleDbType = OracleDbType.Decimal;
                AppId_OP.Value = searchParam.AppId;

                OracleParameter userId_OP = new OracleParameter();
                userId_OP.Direction = System.Data.ParameterDirection.Input;
                userId_OP.OracleDbType = OracleDbType.Decimal;
                userId_OP.Value = searchParam.UserId;

                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = searchParam.FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = searchParam.ToDate;

               


                return (List<SP_GET_RSOPOINT_WEB>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSOPOINT_WEB>.GetDataBySP(new SP_GET_RSOPOINT_WEB(), "SP_FF_GET_RSO_POINT_SUMMARY", 7, resultOutCurSor, zoneId_OP, AppId_OP, userId_OP, FromDate_OP, ToDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
