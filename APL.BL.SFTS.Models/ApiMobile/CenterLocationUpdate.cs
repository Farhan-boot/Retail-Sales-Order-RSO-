using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class CenterLocationUpdate
    {
        public long CenterId { get; set; }
        public decimal LatValue { get; set; }
        public decimal LongValue { get; set; }
    }
}
