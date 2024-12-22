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
    public class RSO_GPS_ATTENDANCEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        #region RSO_GPS_ATTENDANCE
        [DataMember]
        public Decimal RSO_GPS_ATTENDANCE_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal RSO_ID { get; set; }
       
        [DataMember]
        public String DISTRIBUTOR_NAME_CODE { get; set; }

        [DataMember]
        public String RSO_NAME_CODE { get; set; }

        [DataMember]
        public DateTime ATTENDANCE_DATE { get; set; }

        [DataMember]
        public String MOBILE_NO { get; set; }
        
        [DataMember]
        public String HANDSET_NO { get; set; }

        [DataMember]
        public Decimal TOTAL_RETAILER_VISIT { get; set; }
        
        [DataMember]
        public Decimal TOTAL_RECORD { get; set; }

        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        #endregion RSO_GPS_ATTENDANCE

        #region RSO_GPS_ATTENDANCE_DETAIL

        [DataMember]
        public Decimal RSO_GPS_ATTENDANCE_DETAIL_ID { get; set; }
        
        [DataMember]
        public Decimal ROUTE_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; } 

        [DataMember]
        public String RETAILER_NAME_CODE { get; set; }

        [DataMember]
        public Decimal LATITUDE_VALUE { get; set; }

        [DataMember]
        public Decimal LONGITUDE_VALUE { get; set; }

        [DataMember]
        public DateTime ATTEND_DATE_TIME { get; set; }

        [DataMember]
        public String ROUTENAME { get; set; }

        #endregion RSO_GPS_ATTENDANCE_DETAIL

        public object MapToEntity(object[] values)
        {                        
            RSO_GPS_ATTENDANCEcls entity = new RSO_GPS_ATTENDANCEcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.RSO_GPS_ATTENDANCE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO_ID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME_CODE = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.RSO_NAME_CODE = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.ATTENDANCE_DATE = Convert.ToDateTime(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.MOBILE_NO = Convert.ToString(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.HANDSET_NO = Convert.ToString(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.TOTAL_RETAILER_VISIT = Convert.ToDecimal(values[8]);

            if (values[9] != null && values[9].GetType() != typeof(System.DBNull))
                entity.RSO_GPS_ATTENDANCE_DETAIL_ID = Convert.ToDecimal(values[9]);

            if (values[10]!=null && values[10].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[10]);

            if (values[11] != null && values[11].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[11]);

            if (values[12] != null && values[12].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME_CODE = Convert.ToString(values[12]);

            if (values[13] != null && values[13].GetType() != typeof(System.DBNull))
                entity.LATITUDE_VALUE = Convert.ToDecimal(values[13]);

            if (values[14] != null && values[14].GetType() != typeof(System.DBNull))
                entity.LONGITUDE_VALUE = Convert.ToDecimal(values[14]);

            if (values[15] != null && values[15].GetType() != typeof(System.DBNull))
                entity.ATTEND_DATE_TIME = Convert.ToDateTime(values[15]);

            if (values[16] != null && values[16].GetType() != typeof(System.DBNull))
                entity.TOTAL_RECORD = Convert.ToDecimal(values[16]);

            if (values[17] != null && values[17].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[17]);

            if (values[18] != null && values[18].GetType() != typeof(System.DBNull))
                entity.ROUTENAME = Convert.ToString(values[18]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
