using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
   public class IssuePosm
    {
        public decimal Id { get; set; }
        public DateTime ISSUE_DATE { get; set; }
        public decimal STAFF_USERID { get; set; }
        public decimal RETAILERID { get; set; }
		public string ITOPUP_NUMBER { get; set; }
		public decimal CATEGORYID { get; set; }
        public decimal PRODUCTID { get; set; }
        public decimal QTY { get; set; }

        public char strmode { get; set; }





    }
}
