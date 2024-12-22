using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class ProductDelivery
    {
        public long Id { get; set; }
        public decimal ProductId { get; set; }
        public decimal MemoId { get; set; }
        public decimal MemoProductId { get; set; }
        public decimal DeliveryQty { get; set; }
        public string RefId { get; set; }
        public decimal CreatedBy { get; set; }     
    }
}
