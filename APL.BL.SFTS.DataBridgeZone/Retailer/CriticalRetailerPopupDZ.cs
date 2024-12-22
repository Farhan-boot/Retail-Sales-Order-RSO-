using APL.BL.SFTS.DataBridgeZone.SP_Class;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Retailer
{
    public class CriticalRetailerPopupDZ
    {
        public CriticalRetailerPopupDZ()
        { }


        public List<GET_CRITICAL_RETAILERS_POPUP> GetCriticalRetailer(decimal staffUserId, decimal isPopup)
        {
            try
            {
                OracleParameter staffUserId_OP = new OracleParameter();
                staffUserId_OP.Direction = System.Data.ParameterDirection.Input;
                staffUserId_OP.OracleDbType = OracleDbType.Decimal;
                staffUserId_OP.Value = staffUserId;

                OracleParameter isPopup_OP = new OracleParameter();
                isPopup_OP.Direction = System.Data.ParameterDirection.Input;
                isPopup_OP.OracleDbType = OracleDbType.Decimal;
                isPopup_OP.Value = isPopup;


                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_CRITICAL_RETAILERS_POPUP>)ObjectMakerFromOracleSP.OracleHelper<GET_CRITICAL_RETAILERS_POPUP>.GetDataBySP(new GET_CRITICAL_RETAILERS_POPUP(), "GET_CRTCL_RETAILER_POP", 5, resultOutCurSor, staffUserId_OP, isPopup_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
