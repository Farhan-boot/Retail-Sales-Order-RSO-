using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
   public class GetCurrentOfferPicture
    {
       public List<GET_OFFER_PICTURES> data { get; set; }
       public int status_code { get; set; }
    }
}
