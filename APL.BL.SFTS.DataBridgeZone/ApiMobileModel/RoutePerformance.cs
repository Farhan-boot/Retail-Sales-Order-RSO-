using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class RoutePerformance
    {
        public decimal UserId { get; set; }
        public string DistributorCode { get; set; }
        public string AreaCode { get; set; }
        public int Scope { get; set; }
        public string KpiCode { get; set; }      
    }
}
