using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RSO_GPS : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public Decimal VISIT_TIME_LAT { get; set; }

        [DataMember]
        public Decimal VISIT_TIME_LONG { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }
        [DataMember]
        public String DATE_STR { get; set; }
        [DataMember]
        public String LOGIN_TIME { get; set; }
        [DataMember]
        public String LOGOUT_TIME { get; set; }
        [DataMember]
        public String TIME_ELAPSED { get; set; }
        [DataMember]
        public String LAND_MARK { get; set; }
        [DataMember]
        public String RETAILER_LAT_LONG { get; set; }
        [DataMember]
        public String SALES_LAT_LONG { get; set; }
        [DataMember]
        public String DISTANCE { get; set; }
        [DataMember]
        public String CHECKOUT_FEEDBACK { get; set; }
        [DataMember]
        public String TOTAL_SALES_AMOUNT { get; set; }
        [DataMember]
        public String RETAILER_CODE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_GPS entity = new SP_GET_RSO_GPS();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.VISIT_TIME_LAT = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.VISIT_TIME_LONG = Convert.ToDecimal(values[2]);

            if (values[3] != null)
                entity.RSO_CODE = Convert.ToString(values[3]);
            if (values[4] != null)
                entity.DATE_STR = Convert.ToString(values[4]);
            if (values[5] != null)
                entity.LOGIN_TIME = Convert.ToString(values[5]);
            if (values[6] != null)
                entity.LOGOUT_TIME = Convert.ToString(values[6]);
            if (values[7] != null)
                entity.TIME_ELAPSED = Convert.ToString(values[7]);
            if (values[8] != null)
                entity.LAND_MARK = Convert.ToString(values[8]);
            if (values[9] != null)
                entity.RETAILER_LAT_LONG = Convert.ToString(values[9]);
            if (values[10] != null)
                entity.SALES_LAT_LONG = Convert.ToString(values[10]);
            if (values[11] != null)
                entity.DISTANCE = Convert.ToString(values[11]);
            if (values[12] != null)
                entity.CHECKOUT_FEEDBACK = Convert.ToString(values[12]);
            if (values[13] != null)
                entity.TOTAL_SALES_AMOUNT = Convert.ToString(values[13]);

            if (values[14] != null)
                entity.RETAILER_CODE = Convert.ToString(values[14]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
