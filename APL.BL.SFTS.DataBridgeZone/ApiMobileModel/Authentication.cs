using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class Authentication
    {
        public string Token { get; set; }
        public long? UserId { get; set; }
        public bool Status { get; set; }
        public long RsoId { get; set; }
        public string RsoCode { get; set; }
        public string RsoName { get; set; }
        public string TopupNumber { get; set; }
        public string Massege { get; set; }		
		public bool ISversionError { get; set; }
		public long User_Type { get; set; }
		public decimal ERRORID { get; set; }        
        public bool isUpdateAvailable { get; set; }
        public bool isMandatory { get; set; }
        public string downloadUrl { get; set; }

    }
}
