using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_SCROLL_MESSAGE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal MESSAGE_ID { get; set; }  
     
        [DataMember]
        public String MESSAGE { get; set; }

        [DataMember]
        public String DISPLAY_FROM { get; set; }

        [DataMember]
        public String DISPLAY_TO { get; set; }

        [DataMember]
        public Decimal IS_ACTIVE { get; set; }  

        public object MapToEntity(object[] values)
        {
            SP_GET_SCROLL_MESSAGE entity = new SP_GET_SCROLL_MESSAGE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.MESSAGE_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.MESSAGE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISPLAY_FROM = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISPLAY_TO = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[4]);
                     
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
