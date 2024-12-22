using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{ 
   public class GetSimStatus
    {
       public string statusMsgEng { get; set; }
       public string statusMsgBan { get; set; }
       public decimal errCode { get; set; }
       public string errMsgEng { get; set; }
       public string errMsgBan { get; set; }
    }
}
