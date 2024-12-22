using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class RETAILER_TOP_BOTTOMcls
    {
        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME_CODE { get; set; }

        [DataMember]
        public String RETAILER_ADDRESS { get; set; }
   
        [DataMember]
        public DateTime MONTH_DATE { get; set; }

        [DataMember]
        public Decimal RATIO_PERCENT { get; set; }

        //[DataMember]
        //public Decimal TARGET_AMOUNT { get; set; }

        //[DataMember]
        //public Decimal ACHIVEMENT_AMOUNT { get; set; }
      
        //[DataMember]
        //public String PRODUCT_CATEGORY_NAME { get; set; }

    }
}
