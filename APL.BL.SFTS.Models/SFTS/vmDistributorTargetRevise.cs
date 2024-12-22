using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmDistributorTargetRevise
    {
        public decimal Id { get; set; }

        public decimal TargetId { get; set; }

        public decimal TargetDetailId { get; set; }

        public decimal TargetValue { get; set; }

        public decimal RevisedTargetValue { get; set; }

        public string Comments { get; set; }
    }
}
