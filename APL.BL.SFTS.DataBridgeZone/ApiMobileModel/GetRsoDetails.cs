using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class GetRsoDetails
    {
        public decimal ClusterId { get; set; }
        public decimal RegionId { get; set; }
        public decimal ZoneId { get; set; }
        public decimal ItemId { get; set; }     
    }
}
