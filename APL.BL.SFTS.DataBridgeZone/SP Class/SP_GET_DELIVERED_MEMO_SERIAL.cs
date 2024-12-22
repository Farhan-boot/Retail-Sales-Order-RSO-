using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_DELIVERED_MEMO_SERIAL : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public Decimal MEMO_PRODUCT_ID { get; set; }

        [DataMember]
        public Decimal PRODUCT_ID { get; set; }

        [DataMember]
        public String START_SERIAL { get; set; }

        [DataMember]
        public String END_SERIAL { get; set; }

        [DataMember]
        public Decimal QUANTITY { get; set; }    
                      

        public object MapToEntity(object[] values)
        {
            SP_GET_DELIVERED_MEMO_SERIAL entity = new SP_GET_DELIVERED_MEMO_SERIAL();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.MEMO_PRODUCT_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.PRODUCT_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.START_SERIAL = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.END_SERIAL = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.QUANTITY = Convert.ToDecimal(values[5]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
