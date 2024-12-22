using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class SAFInfoDZ
    {
        public SAFInfoDZ() { }

        /// <summary>
        /// Get all SAF info by search parameter.
        /// </summary>
        /// <param name="inReceiveDateFrom"></param>
        /// <param name="inReceiveDateTo"></param>
        /// <param name="inSIMNO"></param>
        /// <param name="inRETAILERID"></param>
        /// <param name="inRSOID"></param>
        /// <returns>List of SAF Info object</returns>
        public List<SP_GET_INS_UPD_SAF_INFOcls> GetAllSAFInfo(DateTime? inReceiveDateFrom, DateTime? inReceiveDateTo, string inSIMNO, Decimal inRETAILERID, Decimal inRSOID)
        {
            try
            {
                OracleParameter inReceiveDateFromOP = new OracleParameter();
                inReceiveDateFromOP.Direction = System.Data.ParameterDirection.Input;
                inReceiveDateFromOP.OracleDbType = OracleDbType.Varchar2;
                inReceiveDateFromOP.Value = inReceiveDateFrom != null ? ((DateTime)inReceiveDateFrom).ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter inReceiveDateToOP = new OracleParameter();
                inReceiveDateToOP.Direction = System.Data.ParameterDirection.Input;
                inReceiveDateToOP.OracleDbType = OracleDbType.Varchar2;
                inReceiveDateToOP.Value = inReceiveDateTo != null ? ((DateTime)inReceiveDateTo).ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter inSIMNO_OP = new OracleParameter();
                inSIMNO_OP.Direction = System.Data.ParameterDirection.Input;
                inSIMNO_OP.OracleDbType = OracleDbType.Varchar2;
                inSIMNO_OP.Value = inSIMNO;

                OracleParameter inRETAILERID_OP = new OracleParameter();
                inRETAILERID_OP.Direction = System.Data.ParameterDirection.Input;
                inRETAILERID_OP.OracleDbType = OracleDbType.Decimal;
                inRETAILERID_OP.Value = inRETAILERID;

                OracleParameter inRSOID_OP = new OracleParameter();
                inRSOID_OP.Direction = System.Data.ParameterDirection.Input;
                inRSOID_OP.OracleDbType = OracleDbType.Decimal;
                inRSOID_OP.Value = inRSOID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_INS_UPD_SAF_INFOcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_INS_UPD_SAF_INFOcls>.GetDataBySP(new SP_GET_INS_UPD_SAF_INFOcls(), "SP_GET_SAF_INFO_ALL", 8, resultOutCurSor, inReceiveDateFromOP, inReceiveDateToOP, inSIMNO_OP, inRETAILERID_OP, inRSOID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get single SAF info by search parameter.
        /// </summary>
        /// <param name="inSIMNO"></param>
        /// <param name="inRETAILERID"></param>
        /// <param name="inRSOID"></param>
        /// <returns>Single SAF Info object</returns>
        public List<SP_GET_INS_UPD_SAF_INFOcls> GetSAFInfoSingle(string inSIMNO, Decimal inRETAILERID, Decimal inRSOID)
        {
            try
            {
                OracleParameter inSIMNO_OP = new OracleParameter();
                inSIMNO_OP.Direction = System.Data.ParameterDirection.Input;
                inSIMNO_OP.OracleDbType = OracleDbType.Varchar2;
                inSIMNO_OP.Value = inSIMNO;

                OracleParameter inRETAILERID_OP = new OracleParameter();
                inRETAILERID_OP.Direction = System.Data.ParameterDirection.Input;
                inRETAILERID_OP.OracleDbType = OracleDbType.Decimal;
                inRETAILERID_OP.Value = inRETAILERID;

                OracleParameter inRSOID_OP = new OracleParameter();
                inRSOID_OP.Direction = System.Data.ParameterDirection.Input;
                inRSOID_OP.OracleDbType = OracleDbType.Decimal;
                inRSOID_OP.Value = inRSOID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_INS_UPD_SAF_INFOcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_INS_UPD_SAF_INFOcls>.GetDataBySP(new SP_GET_INS_UPD_SAF_INFOcls(), "SP_GET_SAF_INFO_SING", 8, resultOutCurSor, inSIMNO_OP, inRETAILERID_OP, inRSOID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all SAF info with paging by search parameter.
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="simNO"></param>
        /// <param name="retailerID"></param>
        /// <param name="rsoID"></param>
        /// <param name="currentPage"></param>
        /// <returns>List of SAF Info object</returns>
        public List<SP_GET_INS_UPD_SAF_INFOcls> Get_SAF_INFO_Paging(DateTime dateFrom, DateTime dateTo, string simNO, decimal retailerID, decimal rsoID, decimal currentPage)
        {
            try
            {

                OracleParameter dateFromOP = new OracleParameter();
                dateFromOP.Direction = ParameterDirection.Input;
                dateFromOP.OracleDbType = OracleDbType.Varchar2;
                dateFromOP.Value = dateFrom.ToString("dd-MMM-yyyy");

                OracleParameter dateToOP = new OracleParameter();
                dateToOP.Direction = ParameterDirection.Input;
                dateToOP.OracleDbType = OracleDbType.Varchar2;
                dateToOP.Value = dateTo.ToString("dd-MMM-yyyy");

                OracleParameter simNO_OP = new OracleParameter();
                simNO_OP.Direction = System.Data.ParameterDirection.Input;
                simNO_OP.OracleDbType = OracleDbType.Varchar2;
                simNO_OP.Value = simNO;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter currentPageOP = new OracleParameter();
                currentPageOP.Direction = ParameterDirection.Input;
                currentPageOP.OracleDbType = OracleDbType.Decimal;
                currentPageOP.Value = currentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_INS_UPD_SAF_INFOcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_INS_UPD_SAF_INFOcls>.GetDataBySP(new SP_GET_INS_UPD_SAF_INFOcls(), "SP_GET_SAF_INFO",
                                    8, resultOutCurSor, dateFromOP, dateToOP, simNO_OP, retailerID_OP, rsoID_OP, currentPageOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save or update SAF Info.
        /// </summary>
        /// <param name="safID"></param>
        /// <param name="receiveDate"></param>
        /// <param name="simNO"></param>
        /// <param name="fromNO"></param>
        /// <param name="retailerID"></param>
        /// <param name="rsoID"></param>
        /// <param name="updateDate"></param>
        /// <param name="updateBy"></param>
        /// <returns>SAF Info ID</returns>
        public decimal SaveSAFInfo(decimal safID, DateTime receiveDate, String simNO, String fromNO, decimal retailerID, decimal rsoID, DateTime updateDate, String updateBy)
        {
            try
            {
                OracleParameter safID_OP = new OracleParameter();
                safID_OP.Direction = ParameterDirection.Input;
                safID_OP.OracleDbType = OracleDbType.Decimal;
                safID_OP.Value = safID;

                OracleParameter receiveDateOP = new OracleParameter();
                receiveDateOP.Direction = System.Data.ParameterDirection.Input;
                receiveDateOP.OracleDbType = OracleDbType.Varchar2;
                receiveDateOP.Value = receiveDate != null ? ((DateTime)receiveDate).ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter simNO_OP = new OracleParameter();
                simNO_OP.Direction = ParameterDirection.Input;
                simNO_OP.OracleDbType = OracleDbType.Varchar2;
                simNO_OP.Value = simNO;

                OracleParameter fromNO_OP = new OracleParameter();
                fromNO_OP.Direction = ParameterDirection.Input;
                fromNO_OP.OracleDbType = OracleDbType.Varchar2;
                fromNO_OP.Value = fromNO;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter updateDateOP = new OracleParameter();
                updateDateOP.Direction = System.Data.ParameterDirection.Input;
                updateDateOP.OracleDbType = OracleDbType.Varchar2;
                receiveDateOP.Value = updateDate != null ? ((DateTime)updateDate).ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter updateBY_OP = new OracleParameter();
                updateBY_OP.Direction = ParameterDirection.Input;
                updateBY_OP.OracleDbType = OracleDbType.Varchar2;
                updateBY_OP.Value = updateBy;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_INS_UPD_SAF_INFOcls>.InsertDataBySP("SP_INS_UPD_SAF_INFO", resultOutID, safID_OP, receiveDateOP, simNO_OP, fromNO_OP, retailerID_OP, rsoID_OP, updateDateOP, updateBY_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
