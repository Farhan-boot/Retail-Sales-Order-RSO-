using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class RetailerCreateRequest
    {
        public decimal Id { get; set; }
        public string CreatedRetailerCode { get; set; }
        public string RetailerName { get; set; }
        public decimal Distributor { get; set; }
        public decimal Teritory { get; set; }
        public string OwnShop { get; set; }
        public string Address { get; set; }
        public decimal ShopSize { get; set; }
        public string OwnerName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public decimal DistrictId { get; set; }
        public decimal ThanaId { get; set; }
        public decimal RequestStatus { get; set; }
        public string RequesterComment { get; set; }
        public string ApproversComment { get; set; }
        public decimal CreatedRetailerId { get; set; }
        public decimal RequestedBy { get; set; }
        public decimal LocLatitude { get; set; }
        public decimal LocLongitude { get; set; }

        public string OtherOperatorCode1 { get; set; }
        public decimal AvgDailyPechrageOp1 { get; set; }
        public decimal AvgWeeklySimOp1 { get; set; }
        public string OtherOperatorCode2 { get; set; }
        public decimal AvgDailyPechrageOp2 { get; set; }
        public decimal AvgWeeklySimOp2 { get; set; }
        public string OtherOperatorCode3 { get; set; }
        public decimal AvgDailyPechrageOp3 { get; set; }
        public decimal AvgWeeklySimOp3 { get; set; }
        public byte[] OutletPicture01 { get; set; }
        public byte[] OutletPicture02 { get; set; }
        public byte[] OutletPicture03 { get; set; }
    }
}
