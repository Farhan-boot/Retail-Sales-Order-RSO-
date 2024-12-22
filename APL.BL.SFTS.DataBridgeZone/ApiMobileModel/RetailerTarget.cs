using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class RetailerTarget
    {
        public decimal TargetId { get; set; }
        public decimal ItemId { get; set; }
        public decimal PeriodId { get; set; }
        public string StaffCode { get; set; }
        public string StaffType { get; set; }
        public decimal Target { get; set; }
        public string SetDate { get; set; }
        public string UpTo { get; set; }
        public decimal ActionFlag { get; set; }
    }
}
