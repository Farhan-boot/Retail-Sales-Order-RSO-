using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class RouteDZ
    {
        public RouteDZ()
        { }

        /// <summary>
        /// This methods is calling to provide all route or particular route info.
        /// </summary>
        /// <param name="distributorID">defualt value is zero for all distributor route</param>
        /// <param name="routeID">defualt value is zero for all route or particular routeID</param>
        /// <returns>List of route object</returns>
        public List<SP_GET_ROUTEcls> GetAllRoute(Decimal distributorID, Decimal routeID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;
               
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ROUTEcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ROUTEcls>.GetDataBySP(new SP_GET_ROUTEcls(), "SP_FF_GET_ROUTE", 7, resultOutCurSor, distributorID_OP, routeID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_DROPDOWN> GetClusters(decimal UserId)
        {
            try
            {

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_DROPDOWN>)ObjectMakerFromOracleSP.OracleHelper<GET_DROPDOWN>.GetDataBySP(new GET_DROPDOWN(), "SP_FF_GET_CLUSTER", 3, resultOutCurSor, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
