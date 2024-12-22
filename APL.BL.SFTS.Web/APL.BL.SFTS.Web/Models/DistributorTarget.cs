using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APL.BL.SFTS.Web.Models
{
    public class DistributorTarget
    {
        public decimal TargetItem { get; set; }
        public decimal TargetPeriod { get; set; }
        public DateTime SetDate { get; set; }
        public bool IsActive { get; set; }
    }
}