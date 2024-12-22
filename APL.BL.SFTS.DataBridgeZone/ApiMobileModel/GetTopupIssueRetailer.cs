using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class GetTopupIssueRetailer
    {
        public decimal RetailerId { get; set; }
        public decimal IssuedBy { get; set; }
        public string PassCode { get; set; }
        public decimal TopupAmt { get; set; }
        public decimal VisitId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
