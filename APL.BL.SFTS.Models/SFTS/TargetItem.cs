using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
    public class TargetItem
    {
        public decimal TargetItemId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal IsActive { get; set; }
        public string UnitName { get; set; } 
    }
}
