using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
    public class DistributorPZ
    {
        public const string _collectionNodePart = "Coll";
        public DistributorPZ()
        { }

        //new method added by Kibria
        public Decimal SaveOrUpdateDistributor(string p_DISTRIBUTOR_NAME, string p_FATHER_NAME, string p_MOTHER_NAME)
        {
            try
            {
                return new DistributorDZ().SaveOrUpdateDistributor(p_DISTRIBUTOR_NAME, p_FATHER_NAME, p_MOTHER_NAME);
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
                return new DistributorDZ().GetAllDistributors();
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
                return new DistributorDZ().GetAllDistributor(distribitorID, routeID, retailerID, isPending, isActive, currentPageNumber);
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
        public List<SP_GET_DISTRIBUTORcls> GetAllDistributor(Decimal distributorID)
        {
            try
            {
                return new DistributorDZ().GetAllDistributor(distributorID, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_DISTRIBUTOR_BY_REG_IDcls> GetDistributor(Decimal regionID, Decimal distributorID, Decimal teritoryID)
        {
            try
            {
                return new DistributorDZ().GetAllRegionDistributorTerri(regionID, distributorID, teritoryID);
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
                return new DistributorDZ().GetDistributorForMultiselect(DistributorId, RegionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
