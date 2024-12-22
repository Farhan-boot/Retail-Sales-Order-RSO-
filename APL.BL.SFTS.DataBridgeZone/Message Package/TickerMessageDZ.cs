using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class TickerMessageDZ
    {
        public TickerMessageDZ()
        {
        }
        public List<SP_GET_TICKER_MESSAGEcls> GetTickerMessageByDate(DateTime displayDate, decimal distributorID)
        {
            try
            {
                OracleParameter displayDateOP = new OracleParameter();
                displayDateOP.Direction = System.Data.ParameterDirection.Input;
                displayDateOP.OracleDbType = OracleDbType.Varchar2;
                displayDateOP.Value = displayDate.ToString("dd-MMM-yyyy");

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TICKER_MESSAGEcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TICKER_MESSAGEcls>.GetDataBySP(new SP_GET_TICKER_MESSAGEcls(), "SP_GET_TICKER_MESSAGE", 8, resultOutCurSor, displayDateOP, distributorID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_TICKER_MESSAGEcls> GetTickerMessageSearch(decimal id, string prepareDateFrom, string prepareDateTo, decimal distributorID, Decimal currentPage)
        {
            try
            {
                OracleParameter tickerMessageId_OP = new OracleParameter();
                tickerMessageId_OP.Direction = System.Data.ParameterDirection.Input;
                tickerMessageId_OP.OracleDbType = OracleDbType.Decimal;
                tickerMessageId_OP.Value = id;

                OracleParameter prepareDateFrom_OP = new OracleParameter();
                prepareDateFrom_OP.Direction = System.Data.ParameterDirection.Input;
                prepareDateFrom_OP.OracleDbType = OracleDbType.Varchar2;
                prepareDateFrom_OP.Value = prepareDateFrom;

                OracleParameter prepareDateTo_OP = new OracleParameter();
                prepareDateTo_OP.Direction = System.Data.ParameterDirection.Input;
                prepareDateTo_OP.OracleDbType = OracleDbType.Varchar2;
                prepareDateTo_OP.Value = prepareDateTo;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter currentPage_OP = new OracleParameter();
                currentPage_OP.Direction = System.Data.ParameterDirection.Input;
                currentPage_OP.OracleDbType = OracleDbType.Decimal;
                currentPage_OP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TICKER_MESSAGEcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TICKER_MESSAGEcls>.GetDataBySP(new SP_GET_TICKER_MESSAGEcls(), "SP_GET_ALL_TICKER_MESSAGE", 8, resultOutCurSor, tickerMessageId_OP, prepareDateFrom_OP, prepareDateTo_OP, distributorID_OP, currentPage_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveUpdateTickerMessage(decimal id, decimal distributorId, DateTime prepareDate, string messageNote,
            DateTime displayStartDate, DateTime displayEndDate)
        {
            try
            {
                OracleParameter id_OP = new OracleParameter();
                id_OP.Direction = System.Data.ParameterDirection.Input;
                id_OP.OracleDbType = OracleDbType.Decimal;
                id_OP.Value = id;

                OracleParameter distributorId_OP = new OracleParameter();
                distributorId_OP.Direction = System.Data.ParameterDirection.Input;
                distributorId_OP.OracleDbType = OracleDbType.Decimal;
                distributorId_OP.Value = distributorId;

                OracleParameter prepareDate_OP = new OracleParameter();
                prepareDate_OP.Direction = System.Data.ParameterDirection.Input;
                prepareDate_OP.OracleDbType = OracleDbType.Date;
                prepareDate_OP.Value = prepareDate;

                OracleParameter messageNote_OP = new OracleParameter();
                messageNote_OP.Direction = System.Data.ParameterDirection.Input;
                messageNote_OP.OracleDbType = OracleDbType.Varchar2;
                messageNote_OP.Value = messageNote;

                OracleParameter displayStartDate_OP = new OracleParameter();
                displayStartDate_OP.Direction = System.Data.ParameterDirection.Input;
                displayStartDate_OP.OracleDbType = OracleDbType.Date;
                displayStartDate_OP.Value = displayStartDate;


                OracleParameter displayEndDate_OP = new OracleParameter();
                displayEndDate_OP.Direction = System.Data.ParameterDirection.Input;
                displayEndDate_OP.OracleDbType = OracleDbType.Date;
                displayEndDate_OP.Value = displayEndDate;

                OracleParameter resultOutRSOGpsAttendanceID = new OracleParameter();
                resultOutRSOGpsAttendanceID.Direction = System.Data.ParameterDirection.Output;
                resultOutRSOGpsAttendanceID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_TICKER_MESSAGEcls>.InsertDataBySP("SP_INS_UP_TICKER_MESSAGE", resultOutRSOGpsAttendanceID, id_OP, distributorId_OP, prepareDate_OP,
                                                                                                     messageNote_OP, displayStartDate_OP, displayEndDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
