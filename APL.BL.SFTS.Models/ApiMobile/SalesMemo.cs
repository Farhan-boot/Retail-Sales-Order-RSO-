using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class SalesMemo
    {
        public decimal MemoId { get; set; }
        public string MemoNo { get; set; }
        public DateTime MemoDate { get; set; }
        public decimal CustomerId { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal IsActive { get; set; }
        public DateTime CanceledDate { get; set; }
        public decimal VisitId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal CreatedBy { get; set; }
    }
}
