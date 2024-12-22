using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class MenuItem
    {
        public decimal ItemId { get; set; }
        public string MenuName { get; set; }
        public string MenuNameB { get; set; }
        public string MenuUrl { get; set; }
        public decimal MenuFor { get; set; }
        public decimal IsActive { get; set; }
        public decimal ActionFlag { get; set; }
        public decimal ParentId { get; set; }
        public decimal IsHeader { get; set; }
        public decimal SrlNo { get; set; }
    }
}
