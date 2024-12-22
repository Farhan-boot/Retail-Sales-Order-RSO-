using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_MEMO : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal MEMO_ID { get; set; }

        [DataMember]
        public Decimal PRODUCT_ID { get; set; }

        [DataMember]
        public String PRODUCT_NAME { get; set; }

        [DataMember]
        public Decimal QUANTITY { get; set; }    
                   
        [DataMember]
        public Decimal AMOUNT { get; set; }

        [DataMember]
        public Decimal STATUS { get; set; }

        [DataMember]
        public Decimal MEMO_PRODUCT_ID { get; set; }

        [DataMember]
        public Decimal DELIVERED_QTY { get; set; }

        [DataMember]
        public Decimal SALES_MEMO_PRODUCT_SERIAL_ID { get; set; }
      

        public object MapToEntity(object[] values)
        {
            SP_GET_MEMO entity = new SP_GET_MEMO();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PRODUCT_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.QUANTITY = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.AMOUNT = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.STATUS = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.MEMO_ID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.MEMO_PRODUCT_ID = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.DELIVERED_QTY = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.SALES_MEMO_PRODUCT_SERIAL_ID = Convert.ToDecimal(values[8]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
