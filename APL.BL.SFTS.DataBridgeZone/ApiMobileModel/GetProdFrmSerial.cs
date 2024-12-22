using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
   public class GetProdFrmSerial
    {
       public List<SP_GET_PRODUCT_FROM_SL> getProdFrmSl { get; set; }
       public decimal errCode { get; set; }
       public string errMsgEng { get; set; }
       public string errMsgBan { get; set; }
    }
}
