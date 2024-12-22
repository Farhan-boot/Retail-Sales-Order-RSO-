using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class ClosingStatus
    {
        public long ClosingStatusId { get; set; }
        public long CenterId { get; set; }
        public DateTime StatusDate { get; set; }
        public string StatusDescription { get; set; }
        public string ClosingTime { get; set; }
        public long CreatedBy { get; set; }
    }
}
