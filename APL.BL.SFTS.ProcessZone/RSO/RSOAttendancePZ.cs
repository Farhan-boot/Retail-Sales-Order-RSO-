using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.Models.SystemCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class RSOAttendancePZ
    {
        public const string _collectionNodePart = "Coll";
        public RSOAttendancePZ()
        { }

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
                return new RSOAttendanceDZ().GetAllRsoGPSAttendance(rsoGpsAttendanceID, distributorID, rsoID, attendanceDate, currentPage);
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
                return new RSOAttendanceDZ().GetAllRsoGPSAttendanceDaily(rsoGpsAttendanceID, distributorID, rsoID, attendanceDate, currentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SP_GET_ATTENDANCE_SUMMARY1> GetAttendanceSummary1(vmCmnParameters cmnParam)
        {
            SearchParam searchParam = new SearchParam();
            searchParam.FromDate = cmnParam.FromDate;
            searchParam.ToDate = cmnParam.ToDate;
            List<SP_GET_ATTENDANCE_SUMMARY1> retailerSales = new List<SP_GET_ATTENDANCE_SUMMARY1>();
            try
            {
                retailerSales = new RSOAttendanceDZ().GetAttendanceSummary1(searchParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerSales;
        }
        public List<SP_GET_ATTENDANCE_SUMMARY2> GetAttendanceSummary2(vmCmnParameters cmnParam)
        {
            SearchParam searchParam = new SearchParam();
            searchParam.FromDate = cmnParam.FromDate;
            searchParam.ToDate = cmnParam.ToDate;
            List<SP_GET_ATTENDANCE_SUMMARY2> retailerSales = new List<SP_GET_ATTENDANCE_SUMMARY2>();
            try
            {
                retailerSales = new RSOAttendanceDZ().GetAttendanceSummary2(searchParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retailerSales;
        }
    }
}
