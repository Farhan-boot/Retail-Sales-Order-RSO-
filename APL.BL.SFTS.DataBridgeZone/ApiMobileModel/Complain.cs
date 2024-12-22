using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class Complain
    {
        public long Id { get; set; }
        public int? TypeId { get; set; }
        public long ComplainFor { get; set; }
        public string ComplainForCode { get; set; }
        public string Description { get; set; }
        public string ResolutionDetail { get; set; }
        public int? StatusId { get; set; }
        public string StatusName { get; set; }
        public long RaisedByUser { get; set; }
        public decimal ComplainForId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
