using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class DistributorDZ
    {
        public DistributorDZ()
        { }

        //new method add by Kibria
        public Decimal SaveOrUpdateDistributor(string p_DISTRIBUTOR_NAME, string p_FATHER_NAME, string p_MOTHER_NAME)
        {
            try
            {
                OracleParameter p_DISTRIBUTOR_NAME_OP = new OracleParameter();
                p_DISTRIBUTOR_NAME_OP.Direction = System.Data.ParameterDirection.Input;
                p_DISTRIBUTOR_NAME_OP.OracleDbType = OracleDbType.NVarchar2;
                p_DISTRIBUTOR_NAME_OP.Value = p_DISTRIBUTOR_NAME;

                OracleParameter p_FATHER_NAME_OP = new OracleParameter();
                p_FATHER_NAME_OP.Direction = System.Data.ParameterDirection.Input;
                p_FATHER_NAME_OP.OracleDbType = OracleDbType.NVarchar2;
                p_FATHER_NAME_OP.Value = p_FATHER_NAME;

                OracleParameter p_MOTHER_NAME_OP = new OracleParameter();
                p_MOTHER_NAME_OP.Direction = System.Data.ParameterDirection.Input;
                p_MOTHER_NAME_OP.OracleDbType = OracleDbType.NVarchar2;
                p_MOTHER_NAME_OP.Value = p_MOTHER_NAME;



                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_DISTRIBUTOR_INFO>.InsertDataBySP("SP_INS_UPD_DISTRIBUTOR_INFO", p_DISTRIBUTOR_NAME_OP, p_FATHER_NAME_OP, p_MOTHER_NAME_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_DISTRIBUTOR> GetAllDistributors()
        {
            try
            { 
                OracleParameter resultOutCursor = new OracleParameter();
                resultOutCursor.Direction = System.Data.ParameterDirection.Output;
                resultOutCursor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTOR>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR>.GetDataBySP(new SP_GET_DISTRIBUTOR(), "SP_GET_DISTRIBUTOR", 16, resultOutCursor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_RETAILER_GPS_LOCcls> GetAllDistributor(decimal distribitorID, decimal routeID, decimal retailerID, decimal isPending, decimal isActive, decimal currentPageNumber)
        {
            try
            {
                OracleParameter distribitorID_OP = new OracleParameter();
                distribitorID_OP.Direction = System.Data.ParameterDirection.Input;
                distribitorID_OP.OracleDbType = OracleDbType.Decimal;
                distribitorID_OP.Value = distribitorID;

                OracleParameter routeID_OP = new OracleParameter();
                routeID_OP.Direction = System.Data.ParameterDirection.Input;
                routeID_OP.OracleDbType = OracleDbType.Decimal;
                routeID_OP.Value = routeID;

                OracleParameter retailerID_OP = new OracleParameter();
                retailerID_OP.Direction = System.Data.ParameterDirection.Input;
                retailerID_OP.OracleDbType = OracleDbType.Decimal;
                retailerID_OP.Value = retailerID;

                OracleParameter isPendingOP = new OracleParameter();
                isPendingOP.Direction = System.Data.ParameterDirection.Input;
                isPendingOP.OracleDbType = OracleDbType.Decimal;
                isPendingOP.Value = isPending;

                OracleParameter isActiveOP = new OracleParameter();
                isActiveOP.Direction = System.Data.ParameterDirection.Input;
                isActiveOP.OracleDbType = OracleDbType.Decimal;
                isActiveOP.Value = isActive;

                OracleParameter currentPageNumberOP = new OracleParameter();
                currentPageNumberOP.Direction = System.Data.ParameterDirection.Input;
                currentPageNumberOP.OracleDbType = OracleDbType.Decimal;
                currentPageNumberOP.Value = currentPageNumber;

                OracleParameter resultOutCursor = new OracleParameter();
                resultOutCursor.Direction = System.Data.ParameterDirection.Output;
                resultOutCursor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_RETAILER_GPS_LOCcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_RETAILER_GPS_LOCcls>.GetDataBySP(new SP_GET_RETAILER_GPS_LOCcls(), "SP_GET_RETAILER_GPS_LOC", 16, resultOutCursor, distribitorID_OP, routeID_OP, retailerID_OP, isPendingOP, isActiveOP, currentPageNumberOP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //new method end

        /// <summary>
        /// This methods is calling to provide all distributor or particular distributor info.
        /// </summary>
        /// <param name="distributorID"> default value is zero for all distributor</param>
        /// <returns></returns>
        public List<SP_GET_DISTRIBUTORcls> GetAllDistributor(Decimal distributorID, Decimal regionID)
        {
            try
            {
                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter regionID_OP = new OracleParameter();
                regionID_OP.Direction = System.Data.ParameterDirection.Input;
                regionID_OP.OracleDbType = OracleDbType.Decimal;
                regionID_OP.Value = regionID;
               
                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTORcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTORcls>.GetDataBySP(new SP_GET_DISTRIBUTORcls(), "SP_FF_GET_DISTRIBUTOR", 4, resultOutCurSor, distributorID_OP, regionID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public List<SP_GET_DISTRIBUTOR_BY_REG_IDcls> GetAllRegionDistributorTerri(decimal regionID, decimal distributorID, decimal territoryID)
        {
            try
            {
                OracleParameter regionID_OP = new OracleParameter();
                regionID_OP.Direction = System.Data.ParameterDirection.Input;
                regionID_OP.OracleDbType = OracleDbType.Decimal;
                regionID_OP.Value = regionID;

                OracleParameter distributorID_OP = new OracleParameter();
                distributorID_OP.Direction = System.Data.ParameterDirection.Input;
                distributorID_OP.OracleDbType = OracleDbType.Decimal;
                distributorID_OP.Value = distributorID;

                OracleParameter territoryID_OP = new OracleParameter();
                territoryID_OP.Direction = System.Data.ParameterDirection.Input;
                territoryID_OP.OracleDbType = OracleDbType.Decimal;
                territoryID_OP.Value = territoryID;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_DISTRIBUTOR_BY_REG_IDcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_DISTRIBUTOR_BY_REG_IDcls>.GetDataBySP(new SP_GET_DISTRIBUTOR_BY_REG_IDcls(), "SP_FF_GET_DIST_BY_REG_ID", 12, resultOutCurSor, regionID_OP, distributorID_OP, territoryID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_ALL_DISTRIBUTOR> GetDistributorForMultiselect(Decimal DistributorId, Decimal RegionId)
        {
            try
            {
                OracleParameter DistributorId_OP = new OracleParameter();
                DistributorId_OP.Direction = System.Data.ParameterDirection.Input;
                DistributorId_OP.OracleDbType = OracleDbType.Decimal;
                DistributorId_OP.Value = DistributorId;

                OracleParameter RegionId_OP = new OracleParameter();
                RegionId_OP.Direction = System.Data.ParameterDirection.Input;
                RegionId_OP.OracleDbType = OracleDbType.Decimal;
                RegionId_OP.Value = RegionId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ALL_DISTRIBUTOR>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ALL_DISTRIBUTOR>.GetDataBySP(new SP_GET_ALL_DISTRIBUTOR(), "SP_FF_GET_DISTRIBUTOR", 4, resultOutCurSor, DistributorId_OP, RegionId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
