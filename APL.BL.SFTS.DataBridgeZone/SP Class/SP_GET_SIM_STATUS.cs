using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class SP_GET_SIM_STATUS
    {       
        public Decimal PRODUCT_ID { get; set; }
        public String PRODUCT_CODE { get; set; }
        public String PRODUCT_NAME { get; set; }
        public String DESCRIPTION { get; set; }
        public Decimal UNIT_PRICE { get; set; }
        public Decimal PRODUCT_CATEGORY_ID { get; set; }
        public String PRODUCT_CATEGORY { get; set; }
        public Decimal PRODUCT_FAMILY_ID { get; set; }
    }
}
