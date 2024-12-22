using APL.BL.SFTS.DataBridgeZone.SP_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class ChangeAppPassword
    {
        public SP_APP_PASSWORD_CHANGE data { get; set; }
        public int status_code { get; set; }
    }
}
