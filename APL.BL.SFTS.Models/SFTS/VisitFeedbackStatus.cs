using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class VisitFeedbackStatus
    {
        public decimal Id { get; set; }
        public string StatusDescription { get; set; }
		public string StatusDescriptionBAN { get; set; }
		public bool IsActive { get; set; }      
    }
}
