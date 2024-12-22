using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class Visit
    {
        public decimal VisitId { get; set; }
        public long VisitPlanId { get; set; }
        public long StaffUserId { get; set; }
        public long EntityType { get; set; }
        public long CenterId { get; set; }
        public long RetailerId { get; set; }
        public decimal VisitTimeLat { get; set; }
        public decimal VisitTimeLong { get; set; }
        public decimal FeedbackStatusId { get; set; }
        public string FeedbackDescription { get; set; }
        public long EntityOtherId { get; set; }
        public string EntityOtherTypeName { get; set; }
        public string EntityOtherName { get; set; }
        public long EntityOrArea { get; set; }
        public long MarketAreaId { get; set; }
        public long VisitTypeId { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public long ReviewedBy { get; set; }
        public long LocationIsValid { get; set; }
        public DateTime LocationValidAt { get; set; }
        public long LocationDiffDistance { get; set; }
    }
}
