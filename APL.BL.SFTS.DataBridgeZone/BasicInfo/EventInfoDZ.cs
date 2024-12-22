using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class EventInfoDZ
    {
        /// <summary>
        /// This methods is calling to provide all event or particular evnet info.
        /// </summary>
        /// <param name="searchEventName"> default value is empty string for all evnet info</param>
        /// <returns>List of event object</returns>
        public List<EVENT_INFOcls> GetAllEventInfo(string searchEventName)
        {
            try
            {             
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                OracleParameter searchEventName_OP = new OracleParameter();
                searchEventName_OP.Direction = System.Data.ParameterDirection.Input;
                searchEventName_OP.OracleDbType = OracleDbType.Varchar2;
                searchEventName_OP.Value = searchEventName;

                return (List<EVENT_INFOcls>)ObjectMakerFromOracleSP.OracleHelper<EVENT_INFOcls>.GetDataBySP(new EVENT_INFOcls(), "SP_GET_EVENT_INFO", 6, resultOutCurSor, searchEventName_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This methods is calling to save or update event info.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="note"></param>
        /// <param name="isActive"></param>
        /// <param name="createBy"></param>
        /// <param name="createDate"></param>
        /// <returns>if save properly return Event Table ID or zero fail save info </returns>
        public Decimal Save(decimal eventInfoID, string name, string note, int isActive, decimal createBy, DateTime createDate)
        {
            try
            {
                OracleParameter eventInfoID_OP = new OracleParameter();
                eventInfoID_OP.Direction = System.Data.ParameterDirection.Input;
                eventInfoID_OP.OracleDbType = OracleDbType.Decimal;
                eventInfoID_OP.Value = eventInfoID;

                OracleParameter name_OP = new OracleParameter();
                name_OP.Direction = System.Data.ParameterDirection.Input;
                name_OP.OracleDbType = OracleDbType.Varchar2;
                name_OP.Value = name;

                OracleParameter note_OP = new OracleParameter();
                note_OP.Direction = System.Data.ParameterDirection.Input;
                note_OP.OracleDbType = OracleDbType.Varchar2;
                note_OP.Value = note;

                OracleParameter isActive_OP = new OracleParameter();
                isActive_OP.Direction = System.Data.ParameterDirection.Input;
                isActive_OP.OracleDbType = OracleDbType.Int32;
                isActive_OP.Value = isActive;

                OracleParameter createBy_OP = new OracleParameter();
                createBy_OP.Direction = System.Data.ParameterDirection.Input;
                createBy_OP.OracleDbType = OracleDbType.Decimal;
                createBy_OP.Value = createBy;

                OracleParameter createDate_OP = new OracleParameter();
                createDate_OP.Direction = System.Data.ParameterDirection.Input;
                createDate_OP.OracleDbType = OracleDbType.Varchar2;
                createDate_OP.Value = createDate.ToString("dd-MMM-yyyy");

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<EVENT_INFOcls>.InsertDataBySP("SP_INS_UPD_EVENT_INFO", resultOutID, eventInfoID_OP,
                    name_OP, note_OP, isActive_OP, createBy_OP, createDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
