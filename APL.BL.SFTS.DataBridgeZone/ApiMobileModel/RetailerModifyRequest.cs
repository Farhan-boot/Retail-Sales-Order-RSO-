using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class RetailerModifyRequest
    {
        public decimal Id { get; set; }
        public string  CurrentName { get; set; }
        public string  ModifiedName { get; set; }
        public string  CurrentOwnShop { get; set; }
        public string  ModifiedOwnShop { get; set; }
        public string  CurrentAddress { get; set; }
        public string  ModifiedAddress { get; set; }
        public decimal CurrentShopSize { get; set; }
        public decimal ModifiedShopSize { get; set; }
        public string  CurrentOwnerName { get; set; }
        public string  ModifiedOwnerName { get; set; }
        public string  CurrentContactPerson { get; set; }
        public string  ModifiedContactPerson { get; set; }
        public string  CurrentContactNo { get; set; }
        public string  ModifiedContactNo { get; set; }
        public decimal CurrentDistrictId { get; set; }
        public decimal ModifiedDistrictId { get; set; }
        public decimal CurrentThanaId { get; set; }
        public decimal ModifiedThanaId { get; set; }
        public decimal RequestStatus { get; set; }
        public string  RequesterComment { get; set; }
        public string  ApproversComment { get; set; }
        public decimal RetailerId { get; set; }
        public string  RetailerCode { get; set; }
        public byte[]  OutletPicture { get; set; }
        public string  OtherOperatorCode1 { get; set; }
        public decimal AvgDailyPechrageOp1 { get; set; }
        public decimal AvgWeeklySimOp1 { get; set; }
        public string OtherOperatorCode2 { get; set; }
        public decimal AvgDailyPechrageOp2 { get; set; }
        public decimal AvgWeeklySimOp2 { get; set; }
        public string OtherOperatorCode3 { get; set; }
        public decimal AvgDailyPechrageOp3 { get; set; }
        public decimal AvgWeeklySimOp3 { get; set; }
        public byte[] OutletPicture02 { get; set; }
        public byte[] OutletPicture03 { get; set; }
    }
}
