using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone
{
   public  class RoutePZ
    {
        public const string _collectionNodePart = "Coll";
        public RoutePZ()
        { }
       
        /// <summary>
        /// This methods is calling to provide all route or particular route info.
        /// </summary>
        /// <param name="distributorID">defualt value is zero for all distributor route</param>
        /// <param name="routeID">defualt value is zero for all route or particular routeID</param>
        /// <returns>List of route object</returns>
        public List<SP_GET_ROUTEcls> GetAllRoute(Decimal distributorID, Decimal routeID)
        {
            try
            {
                return new RouteDZ().GetAllRoute(distributorID, routeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_DROPDOWN> GetClusters(decimal UserId)
        {
            try
            {
                return new RouteDZ().GetClusters(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
