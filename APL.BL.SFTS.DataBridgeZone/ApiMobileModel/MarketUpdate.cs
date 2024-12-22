using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class MarketUpdate
    {
        public decimal Id { get; set; }
        public string DistributorCode { get; set; }
        public string RetailerCode { get; set; }
        public decimal? EventId { get; set; }
        public string EventName { get; set; }
        public string OperatorCode { get; set; }
        public string  Note { get; set; }
        public decimal MarketUpdateTypeId { get; set; }
        public decimal CreatedBy { get; set; }  
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
