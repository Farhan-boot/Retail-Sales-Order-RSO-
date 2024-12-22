using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class RSOAttendanceDZ
    {
        public RSOAttendanceDZ()
        {

        }
       
        /// <summary>
        /// Get all RSO attendance and attendance detail by search option. 
        /// </summary>
        /// <param name="rsoGpsAttendanceID"></param>
        /// <param name="distributorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="attendanceDate"></param>
        /// <param name="currentPage"></param>
        /// <returns>List of related object</returns>
        public List<RSO_GPS_ATTENDANCEcls> GetAllRsoGPSAttendance(Decimal rsoGpsAttendanceID, Decimal distributorID, Decimal rsoID, DateTime? attendanceDate, Decimal currentPage)
        {
            try
            {
                OracleParameter rsoGpsAttendanceID_OP = new OracleParameter();
                rsoGpsAttendanceID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoGpsAttendanceID_OP.OracleDbType = OracleDbType.Decimal;
                rsoGpsAttendanceID_OP.Value = rsoGpsAttendanceID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter currentPage_OP = new OracleParameter();
                currentPage_OP.Direction = System.Data.ParameterDirection.Input;
                currentPage_OP.OracleDbType = OracleDbType.Decimal;
                currentPage_OP.Value = currentPage;

                OracleParameter attendanceDate_OP = new OracleParameter();
                attendanceDate_OP.Direction = System.Data.ParameterDirection.Input;
                attendanceDate_OP.OracleDbType = OracleDbType.Varchar2;
                attendanceDate_OP.Value = attendanceDate != null ? ((DateTime)attendanceDate).ToString("dd-MMM-yyyy") : string.Empty;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<RSO_GPS_ATTENDANCEcls>)ObjectMakerFromOracleSP.OracleHelper<RSO_GPS_ATTENDANCEcls>.GetDataBySP(new RSO_GPS_ATTENDANCEcls(), "SP_GET_RSO_GPS_ATTENDANCE", 19, resultOutCurSor, rsoGpsAttendanceID_OP, distributorID_OP, rsoID_OP, attendanceDate_OP, currentPage_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all RSO attendance only by search option. 
        /// </summary>
        /// <param name="rsoGpsAttendanceID"></param>
        /// <param name="distributorID"></param>
        /// <param name="rsoID"></param>
        /// <param name="attendanceDate"></param>
        /// <param name="currentPage"></param>
        /// <returns>List of related object</returns>
        public List<RSO_GPS_ATTENDANCEcls> GetAllRsoGPSAttendanceDaily(Decimal rsoGpsAttendanceID, Decimal distributorID, Decimal rsoID, DateTime? attendanceDate, Decimal currentPage)
        {
            try
            {
                OracleParameter rsoGpsAttendanceID_OP = new OracleParameter();
                rsoGpsAttendanceID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoGpsAttendanceID_OP.OracleDbType = OracleDbType.Decimal;
                rsoGpsAttendanceID_OP.Value = rsoGpsAttendanceID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter currentPage_OP = new OracleParameter();
                currentPage_OP.Direction = System.Data.ParameterDirection.Input;
                currentPage_OP.OracleDbType = OracleDbType.Decimal;
                currentPage_OP.Value = currentPage;

                OracleParameter attendanceDate_OP = new OracleParameter();
                attendanceDate_OP.Direction = System.Data.ParameterDirection.Input;
                attendanceDate_OP.OracleDbType = OracleDbType.Varchar2;
                attendanceDate_OP.Value = attendanceDate != null ? ((DateTime)attendanceDate).ToString("dd/MM/yyyy") : string.Empty;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<RSO_GPS_ATTENDANCEcls>)ObjectMakerFromOracleSP.OracleHelper<RSO_GPS_ATTENDANCEcls>.GetDataBySP(new RSO_GPS_ATTENDANCEcls(), "SP_GET_RSO_GPS_ATTEND_DAILY", 19, resultOutCurSor, rsoGpsAttendanceID_OP, distributorID_OP, rsoID_OP, attendanceDate_OP, currentPage_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save or update RSO attendance and always save attendance detail. 
        /// </summary>
        /// <param name="rsoGpsAttend"></param>
        /// <param name="handsetNo"></param>
        /// <param name="distribitorID"></param>
        /// <param name="moblieNo"></param>
        /// <param name="attendanceDate"></param>
        /// <param name="rsoID"></param>
        /// <param name="routeID"></param>
        /// <param name="attendeanceDateTime"></param>
        /// <param name="latitudeValue"></param>
        /// <param name="longitudeValue"></param>
        /// <param name="retailerID"></param>
        /// <returns>Attendance ID</returns>
        public Decimal SaveUpdateRSO_GPSAttendance(decimal rsoGpsAttend, String handsetNo, decimal distribitorID, String moblieNo, DateTime attendanceDate, Decimal rsoID, decimal routeID, DateTime attendeanceDateTime, decimal latitudeValue, decimal longitudeValue, decimal retailerID)
        {
            try
            {
                OracleParameter rsoGpsAttendOP = new OracleParameter();
                rsoGpsAttendOP.Direction = System.Data.ParameterDirection.Input;
                rsoGpsAttendOP.OracleDbType = OracleDbType.Decimal;
                rsoGpsAttendOP.Value = rsoGpsAttend;

                OracleParameter handsetNoOP = new OracleParameter();
                handsetNoOP.Direction = System.Data.ParameterDirection.Input;
                handsetNoOP.OracleDbType = OracleDbType.Varchar2;
                handsetNoOP.Value = handsetNo;

                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter moblieNoOP = new OracleParameter();
                moblieNoOP.Direction = System.Data.ParameterDirection.Input;
                moblieNoOP.OracleDbType = OracleDbType.Varchar2;
                moblieNoOP.Value = moblieNo;

                OracleParameter attendanceDateOP = new OracleParameter();
                attendanceDateOP.Direction = System.Data.ParameterDirection.Input;
                attendanceDateOP.OracleDbType = OracleDbType.Date;
                attendanceDateOP.Value = attendanceDate;

                OracleParameter rsoID_OP = new OracleParameter();
                rsoID_OP.Direction = System.Data.ParameterDirection.Input;
                rsoID_OP.OracleDbType = OracleDbType.Decimal;
                rsoID_OP.Value = rsoID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter attendeanceDateTimeOP = new OracleParameter();
                attendeanceDateTimeOP.Direction = System.Data.ParameterDirection.Input;
                attendeanceDateTimeOP.OracleDbType = OracleDbType.Date;
                attendeanceDateTimeOP.Value = attendeanceDateTime;

                OracleParameter latitudeValueOP = new OracleParameter();
                latitudeValueOP.Direction = System.Data.ParameterDirection.Input;
                latitudeValueOP.OracleDbType = OracleDbType.Decimal;
                latitudeValueOP.Value = latitudeValue;

                OracleParameter longitudeValueOP = new OracleParameter();
                longitudeValueOP.Direction = System.Data.ParameterDirection.Input;
                longitudeValueOP.OracleDbType = OracleDbType.Decimal;
                longitudeValueOP.Value = longitudeValue;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter resultOutRSOGpsAttendanceID = new OracleParameter();
                resultOutRSOGpsAttendanceID.Direction = System.Data.ParameterDirection.Output;
                resultOutRSOGpsAttendanceID.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<RSO_GPS_ATTENDANCEcls>.InsertDataBySP("SP_INS_RSO_GPS_ATTEND", resultOutRSOGpsAttendanceID, rsoGpsAttendOP, handsetNoOP, distribitorID_OP, moblieNoOP, attendanceDateOP, rsoID_OP, routeID_OP, attendeanceDateTimeOP, latitudeValueOP, longitudeValueOP, retailerID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_ATTENDANCE_SUMMARY1> GetAttendanceSummary1(SearchParam searchParam)
        {
            try
            {
                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = searchParam.FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = searchParam.ToDate;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ATTENDANCE_SUMMARY1>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ATTENDANCE_SUMMARY1>.GetDataBySP(new SP_GET_ATTENDANCE_SUMMARY1(), "SP_GET_ATTENDANCE_SUMMARY1", 6, resultOutCurSor, FromDate_OP, ToDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_ATTENDANCE_SUMMARY2> GetAttendanceSummary2(SearchParam searchParam)
        {
            try
            {
                OracleParameter FromDate_OP = new OracleParameter();
                FromDate_OP.Direction = System.Data.ParameterDirection.Input;
                FromDate_OP.OracleDbType = OracleDbType.Date;
                FromDate_OP.Value = searchParam.FromDate;

                OracleParameter ToDate_OP = new OracleParameter();
                ToDate_OP.Direction = System.Data.ParameterDirection.Input;
                ToDate_OP.OracleDbType = OracleDbType.Date;
                ToDate_OP.Value = searchParam.ToDate;



                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ATTENDANCE_SUMMARY2>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ATTENDANCE_SUMMARY2>.GetDataBySP(new SP_GET_ATTENDANCE_SUMMARY2(), "SP_GET_ATTENDANCE_SUMMARY2", 7, resultOutCurSor, FromDate_OP, ToDate_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
