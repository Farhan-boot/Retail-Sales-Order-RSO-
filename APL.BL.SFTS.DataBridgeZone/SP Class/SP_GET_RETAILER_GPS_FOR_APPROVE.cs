using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_GPS_FOR_APPROVE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }
        
        [DataMember]
        public Decimal REQUESTED_BY { get; set; }

        [DataMember]
        public String REQUESTED_BY_NAME { get; set; }

        [DataMember]
        public String REQUESTED_DATE { get; set; }

        [DataMember]
        public Decimal NEW_LAT { get; set; }

        [DataMember]
        public Decimal NEW_LONG { get; set; }

        [DataMember]
        public Decimal OLD_LAT { get; set; }

        [DataMember]
        public Decimal OLD_LONG { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String REQUESTERS_COMMENTS { get; set; }

        [DataMember]
        public Decimal REQUEST_STATUS { get; set; }

        [DataMember]
        public String REQUEST_STATUS_NAME { get; set; }

        [DataMember]
        public Decimal APPROVED_BY { get; set; }

       
        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_GPS_FOR_APPROVE entity = new SP_GET_RETAILER_GPS_FOR_APPROVE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.REQUESTED_BY = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.REQUESTED_BY_NAME = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.REQUESTED_DATE = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.NEW_LAT = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.NEW_LONG = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.OLD_LAT = Convert.ToDecimal(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.OLD_LONG = Convert.ToDecimal(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.REQUESTERS_COMMENTS = Convert.ToString(values[12]);
            if (values[13].GetType() != typeof(System.DBNull))
                entity.REQUEST_STATUS = Convert.ToDecimal(values[13]);
            if (values[14].GetType() != typeof(System.DBNull))
                entity.REQUEST_STATUS_NAME = Convert.ToString(values[14]);
            if (values[15].GetType() != typeof(System.DBNull))
                entity.APPROVED_BY = Convert.ToDecimal(values[15]);            

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
