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
    public class SAF_INFO_PENDING
    {
        [DataMember]
        public Decimal RSO_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public DateTime FROM_DATE { get; set; }

        [DataMember]
        public DateTime TO_DATE { get; set; }

        [DataMember]
        public Decimal TOTAL_SIM_SOLD { get; set; }

        [DataMember]
        public Decimal TOTAL_SAF_SUBMIT { get; set; }

        [DataMember]
        public Decimal TOTAL_SIM_PENDING { get; set; }
    }
}
