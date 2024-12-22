using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmCommissionStructure
    {
        public Decimal CommissionId { get; set; }

        public String CommissionName { get; set; }

        public String CommissionDetails { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
   
        public DateTime DisplayFromDate { get; set; }

        public DateTime DisplayToDate { get; set; }

        public Decimal TargetType { get; set; }

        public int IsToAll { get; set; }

        public Decimal StaffRoleId { get; set; }

        public int IsActive { get; set; }
    }
}
