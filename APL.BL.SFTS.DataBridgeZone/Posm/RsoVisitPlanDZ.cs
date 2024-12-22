using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Posm
{
   public class RsoVisitPlanDZ
    {
        readonly string connStringMainDB = ConfigurationManager.ConnectionStrings["APL_DB_ConnString"].ConnectionString;


        public List<SP_GET_RSO_MTD_VISIT_DATA> getRsoMtdData(decimal Id, decimal RsoId)
        {
            try
            {
                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = Id;
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_MTD_VISIT_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_MTD_VISIT_DATA>.GetDataBySP(new SP_GET_RSO_MTD_VISIT_DATA(), "SP_GET_RSO_MTD_DATA", 4, UserId_OP, RsoId_OP, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RSO_MTD_VISIT_DATA> getRsoVisitData(decimal Id, decimal RsoId)
        {
            try
            {
                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = Id;
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_MTD_VISIT_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_MTD_VISIT_DATA>.GetDataBySP(new SP_GET_RSO_MTD_VISIT_DATA(), "SP_GET_RSO_VISIT_DATA", 4, UserId_OP, RsoId_OP, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA> getRsoVisitDtlData(decimal Id, decimal RsoId)
        {
            try
            {
                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;
                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = Id;
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_VISIT_MTD_DETAILS_DATA>.GetDataBySP(new SP_GET_RSO_VISIT_MTD_DETAILS_DATA(), "SP_GET_RSO_VISIT_DETAILS_DATA", 9, UserId_OP, RsoId_OP, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA> getRsoMtdDtlData(decimal Id, decimal RsoId)
        {
            try
            {
                OracleParameter RsoId_OP = new OracleParameter();
                RsoId_OP.Direction = System.Data.ParameterDirection.Input;
                RsoId_OP.OracleDbType = OracleDbType.Decimal;
                RsoId_OP.Value = RsoId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = Id;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RSO_VISIT_MTD_DETAILS_DATA>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RSO_VISIT_MTD_DETAILS_DATA>.GetDataBySP(new SP_GET_RSO_VISIT_MTD_DETAILS_DATA(), "SP_GET_RSO_MTD_DETAILS_DATA", 9, UserId_OP, RsoId_OP, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
