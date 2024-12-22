using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_TRADE_MATERIAL_ISSUE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String ITEM_NAME { get; set; }

        [DataMember]
        public String ISSUE_DATE { get; set; }    
                   
        [DataMember]
        public Decimal ISSUED_QTY { get; set; }  
      

        public object MapToEntity(object[] values)
        {
            SP_GET_TRADE_MATERIAL_ISSUE entity = new SP_GET_TRADE_MATERIAL_ISSUE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ITEM_NAME = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ISSUE_DATE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.ISSUED_QTY = Convert.ToDecimal(values[2]);      
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
