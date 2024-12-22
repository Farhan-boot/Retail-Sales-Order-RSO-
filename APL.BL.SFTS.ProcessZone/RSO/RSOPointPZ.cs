using APL.BL.SFTS.DataBridgeZone.RSO;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using APL.BL.SFTS.Models.SystemCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.RSO
{
    public class RSOPointPZ
    {
        public RSOPointPZ()
        { }

        public List<SP_GET_RSOPOINT_WEB> GetRSOPoints(SearchParam searchParam)//decimal zoneId,string fromDate, decimal appID,decimal userId)
        {
            List<SP_GET_RSOPOINT_WEB> rsoPointList = new List<SP_GET_RSOPOINT_WEB>();
            try
            {
                rsoPointList = new RSOPointDZ().GetRSOPoints(searchParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return rsoPointList;
        }
    }
}
