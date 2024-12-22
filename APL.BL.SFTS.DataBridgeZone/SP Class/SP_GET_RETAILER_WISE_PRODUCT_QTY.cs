using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_WISE_PRODUCT_QTY : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public Decimal AMOUNT { get; set; }

     
        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_WISE_PRODUCT_QTY entity = new SP_GET_RETAILER_WISE_PRODUCT_QTY();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.AMOUNT = Convert.ToDecimal(values[3]);           

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
