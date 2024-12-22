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
    public class SP_GET_RET_GPS_RSO_DATE_WISEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        /// <summary>
        /// ID => Retail ID
        /// </summary>
        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        /// <summary>
        /// CODE => Retail CODE
        /// </summary>
        [DataMember]
        public String RETAIL_CODE { get; set; }

        /// <summary>
        /// NAME => Retail NAME
        /// </summary>
        [DataMember]
        public String RETAIL_NAME { get; set; }

        /// <summary>
        /// DISTRIBUTOR => DISTRIBUTOR ID
        /// </summary>
        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_ROUTE_ID { get; set; }

        [DataMember]
        public Decimal LATITUDE_VALUE { get; set; }

        [DataMember]
        public Decimal LONGITUDE_VALUE { get; set; }
        
        public object MapToEntity(object[] values)
        {
            SP_GET_RET_GPS_RSO_DATE_WISEcls entity = new SP_GET_RET_GPS_RSO_DATE_WISEcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAIL_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAIL_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_ROUTE_ID = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.LATITUDE_VALUE = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.LONGITUDE_VALUE = Convert.ToDecimal(values[6]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
