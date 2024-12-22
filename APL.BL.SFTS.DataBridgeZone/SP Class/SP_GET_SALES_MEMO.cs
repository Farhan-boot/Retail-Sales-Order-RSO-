using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()] 
    [DataContract]
    public class SP_GET_SALES_MEMO : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String MEMO_DATE { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public Decimal PRODUCT_TYPE_ID { get; set; }    
                   
        [DataMember] 
        public Decimal NET_AMOUNT { get; set; }

        [DataMember]
        public Decimal PRODUCT_ID { get; set; }

        [DataMember]
        public String PRODUCT_NAME { get; set; }
         
        [DataMember]
        public Decimal QUANTITY { get; set; }

        [DataMember]
        public Decimal PRICE { get; set; }

        [DataMember]
        public String SERIALS { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_SALES_MEMO entity = new SP_GET_SALES_MEMO();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.MEMO_DATE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PRODUCT_TYPE_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.NET_AMOUNT = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.PRODUCT_ID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.QUANTITY = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.PRICE = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.SERIALS = Convert.ToString(values[9]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
