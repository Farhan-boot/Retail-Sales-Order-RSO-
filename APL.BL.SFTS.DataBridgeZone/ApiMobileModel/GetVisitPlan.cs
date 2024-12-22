using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class GetVisitPlan
    {
        public long VisitPlanId { get; set; }
        public DateTime VisitDate { get; set; }
        public long StaffUserId { get; set; }
        public int EntityType { get; set; }
        public long CenterId { get; set; }
        public long RetailerId { get; set; }
        public int Status { get; set; }
        public long CreatedBy { get; set; }
        public int VisitType { get; set; }
    }
}
