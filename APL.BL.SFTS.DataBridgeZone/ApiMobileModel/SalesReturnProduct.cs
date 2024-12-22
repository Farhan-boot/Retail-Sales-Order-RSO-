using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class SalesReturnProduct
    {
        public decimal Id { get; set; }
        public decimal ReturnId { get; set; }
        public decimal ProductId { get; set; }
        public decimal ReturnQty { get; set; }
        public string Remarks { get; set; }
        public decimal ReturnStatus { get; set; }
        public List<SalesReturnProductSerial> salesReturnProdSls { get; set; }

    }
}
