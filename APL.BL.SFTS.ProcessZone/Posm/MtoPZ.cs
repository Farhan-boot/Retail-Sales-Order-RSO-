using APL.BL.SFTS.DataBridgeZone.RSO;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.RSO
{
   
    public class MtoPZ
    {
        
        public List<Get_RouteList_Fr_MTO> RouteListForMTO(decimal MTOID)
        {
            try
            {
                return new MtoDZ().RouteListForMTO(MTOID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GET_RETAILER_FOR_MTO> RetailerListForMTO(decimal MTOID, decimal route, decimal sso, decimal lso)
        {
            try
            {
                return new MtoDZ().RetailerListForMTO(MTOID, route, sso, lso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

      
       

    }
}
