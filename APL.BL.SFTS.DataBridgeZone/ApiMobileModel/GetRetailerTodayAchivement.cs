using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class GetRetailerTodayAchivement
    {
        public List<SP_FF_RETAILER_ACHIEVEMENT> data { get; set; }
        public int status_code { get; set; }
    }
}
