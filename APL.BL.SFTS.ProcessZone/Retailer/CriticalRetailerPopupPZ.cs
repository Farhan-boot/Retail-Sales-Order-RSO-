using APL.BL.SFTS.DataBridgeZone.Retailer;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Retailer
{
    public class CriticalRetailerPopupPZ
    {
        public CriticalRetailerPopupPZ() { }

        public List<GET_CRITICAL_RETAILERS_POPUP> GetCriticalRetailer(decimal staffUserId, decimal isPopup)
        {
            try
            {
                return new CriticalRetailerPopupDZ().GetCriticalRetailer(staffUserId, isPopup);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
