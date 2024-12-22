using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    public class NoticeSetup
    {
        public Decimal NoticeId { get; set; }

        public decimal NoticeTypeId { get; set; }

        public decimal NoticeForId { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public String Title { get; set; }
        public String Message { get; set; }
        public String Url { get; set; }
        public String FileName { get; set; }
        public decimal IsActive { get; set; }
        public string RegionIds { get; set; }
        public string DistributorIds { get; set; }
        public string ExcelFileName { get; set; }
        public string RtExcelFileName { get; set; }
        public string FlashTimes { get; set; }


    }

    public class NoticeUser
    {
        public Decimal NoticeId { get; set; }
        public decimal RegionDdRsoId { get; set; }
        public String Message_Eng { get; set; }
        public String Message_Ban { get; set; }
        public String FileName { get; set; }

    }
    public class NoticeTime
    {
        public Decimal NoticeId { get; set; }
        public string NtcTime { get; set; }


    }
}
