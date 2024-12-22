using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
   public class GetRetTopupStatus
    {
       public List<SP_GET_RET_TOPUP_STATUS> data { get; set; }
       public int status_code { get; set; }
    }
}
