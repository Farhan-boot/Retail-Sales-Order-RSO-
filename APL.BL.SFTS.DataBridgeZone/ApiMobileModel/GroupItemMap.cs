using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class GroupItemMap
    {
        public decimal MappingId { get; set; }
        public decimal GroupId { get; set; }
        public decimal ItemId { get; set; }
        public string ItemIds { get; set; }
        public decimal MappingFor { get; set; }
        public decimal IsActive { get; set; }
        public decimal ActionFlag { get; set; }
    }
}
