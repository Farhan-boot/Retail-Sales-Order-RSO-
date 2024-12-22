using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
   public class GetRSOBestPractice
    {
       public IEnumerable<SP_GET_BEST_RSO_PRACTICE> data { get; set; }
       public int status_code { get; set; }
    }
}
