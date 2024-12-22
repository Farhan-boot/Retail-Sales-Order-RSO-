using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.ApiMobile
{
    public class SafCollectionLog
    {
        public decimal  Id { get; set; }
        public decimal  UserId { get; set; }
        public decimal  RetailerId { get; set; }
        public DateTime CollectionDate { get; set; }
        public string  SafMsisdn { get; set; }
        public string SafSimNo { get; set; }    
    }
}
