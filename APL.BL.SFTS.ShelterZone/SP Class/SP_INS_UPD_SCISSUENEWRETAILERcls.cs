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
    public class SP_INS_UPD_SCISSUENEWRETAILERcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal SCISSUENEWRETAILER_ID { get; set; }
                
        [DataMember]
        public Decimal RSOID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal ROUTE_ID { get; set; }

        [DataMember]
        public String RETAILER_MOBILE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public String SERIALSTART { get; set; }

        [DataMember]
        public String SERIALEND { get; set; }

        [DataMember]
        public String SMS { get; set; }
        
        [DataMember]
        public Decimal LATITUDE_VALUE { get; set; }

        [DataMember]
        public Decimal LONGITUDE_VALUE { get; set; }

        [DataMember]
        public Decimal STATUS { get; set; }
        
        [DataMember]
        public DateTime UPDATE_DATE { get; set; }

        [DataMember]
        public Decimal UPDATE_BY { get; set; }

        [DataMember]
        public Decimal RETAILER_GPS_INFO_ID { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_INS_UPD_SCISSUENEWRETAILERcls entity = new SP_INS_UPD_SCISSUENEWRETAILERcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.SCISSUENEWRETAILER_ID = Convert.ToDecimal(values[0]);
            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
