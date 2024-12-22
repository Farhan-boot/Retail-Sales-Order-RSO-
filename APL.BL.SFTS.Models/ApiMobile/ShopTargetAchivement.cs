using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class ShopTargetAchivement
    {
        public decimal MonthNo { get; set; }
        public List<SP_GET_SHOP_TARGET_ACHIVE> TargetAchive { get; set; }
    }
}
