using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class SalesReturn
    {
        public decimal ReturnId { get; set; }
        public string ReturnNo { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal CustomerId { get; set; }
        public int ProdTypeId { get; set; } 
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal IsActive { get; set; }
        public DateTime CanceledDate { get; set; }
        public decimal VisitId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal CreatedBy { get; set; }
        public decimal ReturnProductId { get; set; }
        public decimal ProductId { get; set; }
        public decimal ReturnProductSerialId { get; set; }
    }
}
