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
    public class SP_INS_RETAILER_GPSINFOcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }


        [DataMember]
        public Decimal ROUTE_ID { get; set; }


        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public Decimal LATITUDE_VALUE { get; set; }


        [DataMember]
        public Decimal LONGITUDE_VALUE { get; set; }


        [DataMember]
        public DateTime CREATE_DATE { get; set; }

        [DataMember]
        public Decimal CREATE_BY { get; set; }

        [DataMember]
        public Decimal RETAILER_GPS_INFO_ID { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_INS_RETAILER_GPSINFOcls entity = new SP_INS_RETAILER_GPSINFOcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_GPS_INFO_ID = Convert.ToDecimal(values[0]);

            //if (values[0].GetType() != typeof(System.DBNull))
            //    entity.DISTRIBUTORID = Convert.ToDecimal(values[0]);
            //if (values[1].GetType() != typeof(System.DBNull))
            //    entity.ROUTEID = Convert.ToDecimal(values[1]);
            //if (values[2].GetType() != typeof(System.DBNull))
            //    entity.RETAILERID = Convert.ToDecimal(values[2]);
            //if (values[3].GetType() != typeof(System.DBNull))
            //    entity.LATITUDE_VALUE = Convert.ToDecimal(values[3]);
            //if (values[4].GetType() != typeof(System.DBNull))
            //    entity.LONGITUDE_VALUE = Convert.ToDecimal(values[4]);
            //if (values[5].GetType() != typeof(System.DBNull))
            //    entity.CREATE_DATE = Convert.ToDateTime(values[5]);
            //if (values[6].GetType() != typeof(System.DBNull))
            //    entity.CREATE_BY = Convert.ToDecimal(values[5]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
