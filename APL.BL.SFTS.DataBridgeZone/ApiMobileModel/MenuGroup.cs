using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class MenuGroup
    {
        public decimal GroupId { get; set; }
        public string GroupName { get; set; }
        public decimal GroupFor { get; set; }
        public decimal IsActive { get; set; }
        public decimal ActionFlag { get; set; }
    }
}
