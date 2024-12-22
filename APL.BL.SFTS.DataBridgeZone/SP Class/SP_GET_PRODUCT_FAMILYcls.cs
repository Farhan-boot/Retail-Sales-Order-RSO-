using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_PRODUCT_FAMILYcls : ObjectMakerFromOracleSP.ISpClassEntity
    {         
        [DataMember]
        public Decimal PRODUCT_FAMILY_ID { get; set; }    
                   
        [DataMember]
        public String PRODUCT_FAMILY_CODE{ get; set; }  
           
        [DataMember]
        public String  PRODUCT_FAMILY_DESC{ get; set; } 
             
        [DataMember]
        public String CREATEDBY{ get; set; }  
            
        [DataMember]
        public String  CREATEDDATE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_PRODUCT_FAMILYcls entity = new SP_GET_PRODUCT_FAMILYcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PRODUCT_FAMILY_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.PRODUCT_FAMILY_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.PRODUCT_FAMILY_DESC = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.CREATEDBY = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.CREATEDDATE = Convert.ToString(values[4]);
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
