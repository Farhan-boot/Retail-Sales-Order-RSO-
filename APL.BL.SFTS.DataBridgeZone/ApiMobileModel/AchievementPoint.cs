using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
   public class AchievementPoint
    {
        public decimal PointId { get; set; }
        public string PointName { get; set; }
        public string PointCode { get; set; }
        public decimal PointScore { get; set; }
        public decimal IsActive { get; set; }
        public decimal ActionFlag { get; set; }
    }
}
