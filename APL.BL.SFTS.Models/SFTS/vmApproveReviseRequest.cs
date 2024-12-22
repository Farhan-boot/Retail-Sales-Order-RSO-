using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmApproveReviseRequest
    {
        public decimal TargetId { get; set; }

        public decimal ActionType { get; set; }

        public string ApproverComment { get; set; }
    }
}
