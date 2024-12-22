using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_CREATE_REQUEST : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String REQUEST_DATE { get; set; }

        [DataMember]
        public String NAME { get; set; }

        [DataMember]
        public Decimal REQUEST_STATUS { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_CREATE_REQUEST entity = new SP_GET_RETAILER_CREATE_REQUEST();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.REQUEST_DATE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.REQUEST_STATUS = Convert.ToDecimal(values[3]);     
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
