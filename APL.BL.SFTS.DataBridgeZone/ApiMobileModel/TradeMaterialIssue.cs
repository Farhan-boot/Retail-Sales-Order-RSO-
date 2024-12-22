using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class TradeMaterialIssue
    {
        public decimal Id { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal IssuedByUser { get; set; }
        public decimal ReceiverType { get; set; }
        public decimal ReceiverId { get; set; }
        public decimal IsCanceled { get; set; }
        public decimal CanceledDate { get; set; }
        public decimal CreatedBy { get; set; }

        //Detail
        public decimal TradeMaterialIssueDetailId { get; set; }
        public decimal IssueId { get; set; }
        public decimal MaterialId { get; set; }
        public decimal IssueQty { get; set; }
        public decimal CanceledBy { get; set; }
    }
}
