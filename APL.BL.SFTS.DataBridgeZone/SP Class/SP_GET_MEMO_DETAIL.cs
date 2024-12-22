using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_MEMO_DETAIL : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public String PRODUCTS { get; set; }

        [DataMember]
        public Decimal AMOUNT { get; set; }

        [DataMember]
        public Decimal MEMO_ID { get; set; }

        [DataMember]
        public String RETAILER_ADDRESS { get; set; }

        [DataMember]
        public DateTime CREATED_TIME { get; set; }

        [DataMember]
        public Decimal NUMBER_OF_PRODUCTS { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_MEMO_DETAIL entity = new SP_GET_MEMO_DETAIL();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRODUCTS = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.AMOUNT = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.MEMO_ID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.RETAILER_ADDRESS = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.CREATED_TIME = Convert.ToDateTime(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.NUMBER_OF_PRODUCTS = Convert.ToDecimal(values[8]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
