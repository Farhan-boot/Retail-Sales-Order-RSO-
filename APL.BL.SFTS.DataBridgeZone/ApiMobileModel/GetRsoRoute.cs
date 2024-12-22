using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
   public class GetRsoRoute
    {
       public decimal ROUTE_ID { get; set; }
       public string ROUTE_NAME { get; set; }
       public string ROUTE_CODE { get; set; }
       public List<SP_GET_RETAILER_ROUTE> RETAILER { get; set; }
    }
}
