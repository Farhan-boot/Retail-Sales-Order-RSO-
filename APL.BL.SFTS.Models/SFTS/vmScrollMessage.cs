using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class vmScrollMessage
    {
        public decimal MessageId { get; set; }
        public string Message { get; set; }
        public DateTime DisplayFrom { get; set; }
        public DateTime DisplayTo { get; set; }
        public bool IsActive { get; set; }
    }
}
