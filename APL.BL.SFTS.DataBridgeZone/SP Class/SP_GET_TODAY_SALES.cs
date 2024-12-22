using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_TODAY_SALES : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String PRODUCT_NAME { get; set; }

        [DataMember]
        public Decimal QUANTITY { get; set; }

        [DataMember]
        public Decimal AMOUNT { get; set; }

        [DataMember]
        public Decimal CATEGORY_ID { get; set; }

        [DataMember]
        public String CATEGORY_NAME { get; set; }

        [DataMember]
        public long ID { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_TODAY_SALES entity = new SP_GET_TODAY_SALES();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.QUANTITY = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.AMOUNT = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.CATEGORY_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.CATEGORY_NAME = Convert.ToString(values[4]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToInt64(values[6]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
