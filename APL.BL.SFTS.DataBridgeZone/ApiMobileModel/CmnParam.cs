using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class CmnParam
    {
        public long UserId { get; set; }
        public decimal RetailerId { get; set; }
        public string Token { get; set; }
        public string DayName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal ProductId { get; set; }
        public decimal ProdTypeId { get; set; } 
        public string CriticalType { get; set; }
        public string StartSl { get; set; }
        public string EndSl { get; set; }
        public string SimNo { get; set; }
        public decimal TempMemoId { get; set; }
        public string MemoId { get; set; }
        public decimal ReturnId { get; set; }
        public decimal IssueId { get; set; }
        public long MSISDN { get; set; }
        public string PinNo { get; set; }
        public string Password { get; set; }
        public decimal TopupIssueStatus { get; set; }

		public decimal ProductCategory { get; set; }
		public decimal SSO { get; set; }
		public decimal LSO { get; set; }
		public decimal ROUTE { get; set; }

		public decimal DDID { get; set; }
		public decimal Monthid { get; set; }
		public decimal CommissionId { get; set; }
		public decimal PeriodType { get; set; }
		public decimal IsPopup { get; set; }

        public decimal LanguageId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int status { get; set; }

        public decimal Amount { get; set; }

        public string DeviceId { get; set; }

        public string UserCode { get; set; }

        public string AppVersion { get; set; }

        public decimal OTP { get; set; }

        public decimal UserType { get; set; }

        public decimal TrainingId { get; set; }

        public decimal StockId { get; set; }
		public decimal ItemType { get; set; }

		public string DDMSISDN { get; set; }
		public string IMEI { get; set; }


	}
}
  
