using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_SALES_STOCK : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String ITEM_CATEGORY { get; set; }

        [DataMember]
        public Decimal AVERAGE_SALES { get; set; }    
                   
        [DataMember]
        public Decimal CURRENT_STOCK { get; set; }  
      

        public object MapToEntity(object[] values)
        {
            SP_GET_SALES_STOCK entity = new SP_GET_SALES_STOCK();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ITEM_CATEGORY = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.AVERAGE_SALES = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.CURRENT_STOCK = Convert.ToDecimal(values[2]);      
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
