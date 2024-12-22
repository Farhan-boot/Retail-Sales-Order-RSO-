using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{ 
    public class SalesReturnProductSerial
    {
        public decimal Id { get; set; }
        public decimal SalesMemoProductId { get; set; }
        public decimal ProductId { get; set; }
        public string  StartSerial { get; set; }
        public string  EndSerial { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalQty { get; set; }
    }
}
