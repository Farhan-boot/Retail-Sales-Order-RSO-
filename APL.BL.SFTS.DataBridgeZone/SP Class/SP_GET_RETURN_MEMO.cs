using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()] 
    [DataContract]
    public class SP_FF_GET_RETURN_MEMO : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String RETURN_DATE { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public Decimal PRODUCT_TYPE_ID { get; set; }    
                   
        [DataMember]
        public Decimal PRODUCT_ID { get; set; }

        [DataMember]
        public String PRODUCT_NAME { get; set; }
         
        [DataMember]
        public Decimal QUANTITY { get; set; }

        [DataMember]
        public String SERIALS { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_FF_GET_RETURN_MEMO entity = new SP_FF_GET_RETURN_MEMO();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETURN_DATE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRODUCT_TYPE_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.PRODUCT_ID = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.QUANTITY = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.SERIALS = Convert.ToString(values[7]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
