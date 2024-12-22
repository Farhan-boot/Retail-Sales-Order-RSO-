using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class EndCallInfoDZ
    {
        public List<ENDCALL_INFOcls> GetAllEndCallInfo(decimal distributorID, decimal rsoID, decimal retailerID, string endCallNote, decimal callStatus, DateTime fromDate, DateTime toDate, decimal currentPage)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;                

                OracleParameter endCallNoteOP = new OracleParameter();
                endCallNoteOP.Direction = System.Data.ParameterDirection.Input;
                endCallNoteOP.OracleDbType = OracleDbType.Varchar2;
                endCallNoteOP.Value = endCallNote;

                OracleParameter callStatus_OP = new OracleParameter();
                callStatus_OP.Direction = System.Data.ParameterDirection.Input;
                callStatus_OP.OracleDbType = OracleDbType.Decimal;
                callStatus_OP.Value = callStatus;

                OracleParameter fromDateOP = new OracleParameter();
                fromDateOP.Direction = System.Data.ParameterDirection.Input;
                fromDateOP.OracleDbType = OracleDbType.Varchar2;
                fromDateOP.Value = fromDate.ToString("dd-MMM-yyyy");

                OracleParameter toDateOP = new OracleParameter();
                toDateOP.Direction = System.Data.ParameterDirection.Input;
                toDateOP.OracleDbType = OracleDbType.Varchar2;
                toDateOP.Value = toDate.ToString("dd-MMM-yyyy"); 

                OracleParameter currentPageOP = new OracleParameter();
                currentPageOP.Direction = System.Data.ParameterDirection.Input;
                currentPageOP.OracleDbType = OracleDbType.Decimal;
                currentPageOP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<ENDCALL_INFOcls>)ObjectMakerFromOracleSP.OracleHelper<ENDCALL_INFOcls>.GetDataBySP(new ENDCALL_INFOcls(), "SP_GET_END_CALL", 14, resultOutCurSor, distributorID_OP, rsoID_OP, retailerID_OP, endCallNoteOP, callStatus_OP, fromDateOP, toDateOP, currentPageOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public Decimal SaveOrUpdate(DateTime  dateTimeCall, decimal distributorID, decimal updateBy, DateTime updateDate, decimal endCallInfoID , string callNote, decimal  rsoID, decimal  retailerID, decimal callStatus)
        {
            try
            {
                OracleParameter dateTimeCallOP = new OracleParameter();
                dateTimeCallOP.Direction = System.Data.ParameterDirection.Input;
                dateTimeCallOP.OracleDbType = OracleDbType.Date;
                dateTimeCallOP.Value = dateTimeCall;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter updateByOP = new OracleParameter();
                updateByOP.Direction = System.Data.ParameterDirection.Input;
                updateByOP.OracleDbType = OracleDbType.Decimal;
                updateByOP.Value = updateBy;

                OracleParameter updateDateOP = new OracleParameter();
                updateDateOP.Direction = System.Data.ParameterDirection.Input;
                updateDateOP.OracleDbType = OracleDbType.Date;
                updateDateOP.Value = updateDate;               

                OracleParameter endCallInfoID_OP = new OracleParameter();
                endCallInfoID_OP.Direction = System.Data.ParameterDirection.Input;
                endCallInfoID_OP.OracleDbType = OracleDbType.Decimal;
                endCallInfoID_OP.Value = endCallInfoID;

                OracleParameter callNoteOP = new OracleParameter();
                callNoteOP.Direction = System.Data.ParameterDirection.Input;
                callNoteOP.OracleDbType = OracleDbType.Varchar2;
                callNoteOP.Value = callNote;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;        

                OracleParameter callStatusOP = new OracleParameter();
                callStatusOP.Direction = System.Data.ParameterDirection.Input;
                callStatusOP.OracleDbType = OracleDbType.Decimal;
                callStatusOP.Value = callStatus;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<ENDCALL_INFOcls>.InsertDataBySP("SP_INS_UPD_ENDCALL_INFO", resultOutID, dateTimeCallOP, distributorID_OP, updateByOP, updateDateOP, endCallInfoID_OP, callNoteOP, rsoID_OP, retailerID_OP, callStatusOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
