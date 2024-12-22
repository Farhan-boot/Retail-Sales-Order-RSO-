using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class SalesMemoProduct
    {
        public decimal Id { get; set; }
        public decimal MemoId { get; set; }
        public decimal ProductId { get; set; }
        public decimal SalesQty { get; set; }
        public decimal Price { get; set; }
        public string Remarks { get; set; }
        public decimal DeliveryStatus { get; set; }
        public List<SalesMemoProductSerial> salesMemoProdSls { get; set; }

    }
}
