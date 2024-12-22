using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
   public class BestPracticesRetailer
    {
        public Decimal BestPracticesRetailerId { get; set; }

        public Decimal RetailerId { get; set; }

        public Decimal RetailerMarketAreaId { get; set; }

        public Decimal PeriodId { get; set; }

        public Decimal Year { get; set; }

        public Decimal CalculationAreaId { get; set; }

        public string Description { get; set; }

        public Decimal CreatedBy { get; set; }
    }
}
