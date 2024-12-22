using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class Authentication
    {
        public string Token { get; set; }
        public long? UserId { get; set; }
        public bool Status { get; set; }
        public string Massege { get; set; }
    }
}
