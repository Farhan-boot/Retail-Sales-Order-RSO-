using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_MARKET_UPDATE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public Decimal CAMPTURED_BY_USER { get; set; }

        [DataMember]
        public String CAMPTURED_BY_USER_NAME { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public String EVENT_NAME { get; set; }

        [DataMember]
        public String OPERATOR_CODE { get; set; }

        [DataMember]
        public String NOTE { get; set; }

        [DataMember]
        public String UPDATED_DATE { get; set; }

        [DataMember]
        public Decimal EVENT_ID { get; set; }

        [DataMember]
        public Decimal MARKET_UPDATE_TYPE_ID { get; set; }

        [DataMember]
        public String MARKET_UPDATE_TYPE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_MARKET_UPDATE entity = new SP_GET_MARKET_UPDATE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.CAMPTURED_BY_USER = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.CAMPTURED_BY_USER_NAME = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.EVENT_NAME = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.OPERATOR_CODE = Convert.ToString(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.NOTE = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.UPDATED_DATE = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.MARKET_UPDATE_TYPE_ID = Convert.ToDecimal(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.MARKET_UPDATE_TYPE = Convert.ToString(values[12]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
