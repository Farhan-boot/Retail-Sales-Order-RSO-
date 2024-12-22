using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_LIFTING_DETAIL : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String LIFTING_DATE { get; set; }

        [DataMember]
        public String INVOICE { get; set; }    
                   
        [DataMember]
        public String PRODUCT_NAME { get; set; }  
           
        [DataMember]
        public Decimal QUANTITY { get; set; } 
             
        [DataMember]
        public Decimal TOTAL_PRICE{ get; set; }

        [DataMember]
        public Decimal CATEGORY_ID { get; set; }

        [DataMember]
        public String CATEGORY_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_LIFTING_DETAIL entity = new SP_GET_LIFTING_DETAIL();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.LIFTING_DATE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.INVOICE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.PRODUCT_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.QUANTITY = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.TOTAL_PRICE = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.CATEGORY_ID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.CATEGORY_NAME = Convert.ToString(values[6]);   
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
