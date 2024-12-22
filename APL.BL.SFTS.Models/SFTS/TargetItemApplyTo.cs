using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class TargetItemApplyTo
    {
        public decimal TargetItemApplyToId { get; set; }
        public decimal TargetItemId { get; set; }
        public decimal ChannelTypeId { get; set; }
        public decimal TargetEntityType { get; set; }
        public decimal? StaffTypeId { get; set; }
        public decimal? CenterTypeId { get; set; }
        public decimal DistributorIsSumOfStaff { get; set; }
        public decimal StaffIsSumOfCenter { get; set; }
        public decimal IsActive { get; set; }
    }
}
