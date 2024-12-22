using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
   public class GetRoutePerformance
    {
       public List<SP_GET_ROUTE_PERFORMANCE> data { get; set; }
       public int status_code { get; set; }
    }
}
