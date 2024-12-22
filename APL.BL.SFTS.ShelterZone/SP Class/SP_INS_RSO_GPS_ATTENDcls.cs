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
    public class SP_INS_RSO_GPS_ATTENDcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        #region RSO_GPS_ATTENDANCE
        [DataMember]
        public Decimal RSO_GPS_ATTENDANCE_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal RSO_ID { get; set; }

        [DataMember]
        public DateTime ATTENDANCE_DATE { get; set; }

        [DataMember]
        public String MOBILE_NO { get; set; }
        
        [DataMember]
        public String HANDSET_NO { get; set; }

        [DataMember]
        public Decimal TOTAL_RETAILER_VISIT { get; set; }

        #endregion RSO_GPS_ATTENDANCE

        #region RSO_GPS_ATTENDANCE_DETAIL

        [DataMember]
        public Decimal RSO_GPS_ATTENDANCE_DETAIL_ID { get; set; }
        
        [DataMember]
        public Decimal ROUTE_ID { get; set; }


        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public Decimal LATITUDE_VALUE { get; set; }


        [DataMember]
        public Decimal LONGITUDE_VALUE { get; set; }


        [DataMember]
        public DateTime ATTEND_DATE_TIME { get; set; }
        #endregion RSO_GPS_ATTENDANCE_DETAIL

        public object MapToEntity(object[] values)
        {
            SP_INS_RSO_GPS_ATTENDcls entity = new SP_INS_RSO_GPS_ATTENDcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.RSO_GPS_ATTENDANCE_ID = Convert.ToDecimal(values[0]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
