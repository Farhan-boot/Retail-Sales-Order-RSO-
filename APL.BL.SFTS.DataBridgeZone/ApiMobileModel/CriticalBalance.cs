using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class CriticalBalance
    {
        public decimal CriticalBalanceId { get; set; }
        public string RetailerCode { get; set; }
        public string DistributorCode { get; set; }
        public string ProductName { get; set; }
        public decimal Saturday { get; set; }
        public decimal Sunday { get; set; }
        public decimal Monday { get; set; }
        public decimal Tuesday { get; set; }
        public decimal Wednesday { get; set; }
        public decimal Thursday { get; set; }
        public decimal Friday { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public decimal IsActive { get; set; }
        public decimal ActionFlag { get; set; }
    }
}


           