using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class RSORouteDZ
    {
        public RSORouteDZ() {}
       
        /// <summary>
        /// Get Valide RSO from RSO and RSO_APP_PASSWORD table.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="pass"></param>
        /// <returns>List of related object</returns>
        public List<SP_RSO_BY_CODE_PASScls> GetROSByCodeAndPass(String code, String pass)
        {
            try
            {
                OracleParameter codeOP = new OracleParameter();
                codeOP.Direction = System.Data.ParameterDirection.Input;
                codeOP.OracleDbType = OracleDbType.Varchar2;
                codeOP.Value = code;

                OracleParameter passOP = new OracleParameter();
                passOP.Direction = System.Data.ParameterDirection.Input;
                passOP.OracleDbType = OracleDbType.Varchar2;
                passOP.Value = pass;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_RSO_BY_CODE_PASScls>)ObjectMakerFromOracleSP.OracleHelper<SP_RSO_BY_CODE_PASScls>.GetDataBySP(new SP_RSO_BY_CODE_PASScls(), "SP_RSO_BY_CODE_PASS", 9, resultOutCurSor, codeOP, passOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all RSO schedule with visiting particular Route from RSOSCHEDULE table.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="visitDate"></param>
        /// <param name="distributorID"></param>
        /// <returns>List of related object</returns>
        public List<SP_GET_RSO_ROT_SCHDLcls> GetROS_RouteWiseSchedule(decimal rsoID, DateTime visitDate, decimal distributorID)
        {
            try
            {
                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter visitDateDateOP = new OracleParameter();
                visitDateDateOP.Direction = System.Data.ParameterDirection.Input;
                visitDateDateOP.OracleDbType = OracleDbType.Varchar2;
                visitDateDateOP.Value = visitDate.ToString("dd-MMM-yyyy");

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                //return (List<SP_GET_RSO_ROT_SCHDLcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_ROT_SCHDLcls>.GetDataBySP(new SP_GET_RSO_ROT_SCHDLcls(), "SP_GET_RSO_WISE_ROT_A_RET", 5, resultOutCurSor, rsoID_OP, visitDateDateOP, distributorID_OP);

                return (List<SP_GET_RSO_ROT_SCHDLcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_ROT_SCHDLcls>.GetDataBySP(new SP_GET_RSO_ROT_SCHDLcls(), "SP_GET_RSO_ROT_SCHDL", 5, resultOutCurSor, rsoID_OP, visitDateDateOP, distributorID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //RetailerStatus
        
        /// <summary>
        /// Get all Retailer visiting schedule(OUTLETSCHEDULE) for particular route by RSO visit.
        /// </summary>
        /// <param name="rsoID"></param>
        /// <param name="assignDate"></param>
        /// <param name="distributorID"></param>
        /// <returns>List of related object<returns>
        public List<SP_GET_RSO_WISE_ROT_A_RETcls> GetROS_WiseRouteAndRetailer(decimal rsoID, DateTime assignDate, decimal distributorID)
        {
            try
            {
                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter assignDateOP = new OracleParameter();
                assignDateOP.Direction = System.Data.ParameterDirection.Input;
                assignDateOP.OracleDbType = OracleDbType.Varchar2;
                assignDateOP.Value = assignDate.ToString("dd-MMM-yyyy");

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_WISE_ROT_A_RETcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_WISE_ROT_A_RETcls>.GetDataBySP(new SP_GET_RSO_WISE_ROT_A_RETcls(), "SP_GET_RSO_WISE_ROT_A_RET", 9, resultOutCurSor, rsoID_OP, assignDateOP, distributorID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
