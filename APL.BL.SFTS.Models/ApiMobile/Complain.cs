using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class Complain
    {
        public long ComplainId { get; set; }
        public long ComplainFor { get; set; }
        public long ComplainForId { get; set; }
    }
}
