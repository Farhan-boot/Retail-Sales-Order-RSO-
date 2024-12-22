using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class SearchParam
    {
        public decimal ClusterId { get; set; }
        public decimal RegionId { get; set; }
        public decimal ZoneId { get; set; }
        public decimal ItemId { get; set; }     
        public DateTime? FromDate { get; set; }     
        public DateTime? ToDate { get; set; }     
        public string TDate { get; set; }     
        public string SurveyName { get; set; }     
        public decimal SurveyId { get; set; }     
        public decimal AppId { get; set; }     
        public decimal UserId { get; set; }     
    }
}
