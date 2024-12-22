using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class TargetExcelTemplate
    {
        public string MonthName { get; set; }
        public string ItemName { get; set; }
        public string Region { get; set; }
        public string Zone { get; set; }
        public string Distributor { get; set; }
        public string StaffCode { get; set; }
        public string StaffName { get; set; }
        public string TargetValue { get; set; }
    }
}
