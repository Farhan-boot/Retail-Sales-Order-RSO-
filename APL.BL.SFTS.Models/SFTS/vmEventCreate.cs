using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmEventCreate
    {
        public decimal EventId { get; set; }
        public string EventName { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public bool IsToAll { get; set; }   
    }
}
