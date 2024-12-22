using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_MESSAGE : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String MESSAGE { get; set; }  
           

        public object MapToEntity(object[] values)
        {
            SP_GET_MESSAGE entity = new SP_GET_MESSAGE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.MESSAGE = Convert.ToString(values[0]);
                     
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
