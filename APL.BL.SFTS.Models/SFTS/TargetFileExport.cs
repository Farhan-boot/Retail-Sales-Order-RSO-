using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
    public class TargetFileExport
    {
        public decimal TargetItemId { get; set; }
        public decimal TargetPeriodId { get; set; }
        public decimal TargetFor { get; set; }
        public decimal StaffTypeId { get; set; }
        public bool InitialVersion { get; set; }
    }
}
