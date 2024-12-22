using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_ROLE_WISE_PERMISSION : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public Decimal ROLE_ID { get; set; }

        [DataMember]
        public Decimal PERMISSION_ID { get; set; }

        [DataMember]
        public String PERMISSION_CODE { get; set; }
        

        public object MapToEntity(object[] values)
        {
            SP_GET_ROLE_WISE_PERMISSION entity = new SP_GET_ROLE_WISE_PERMISSION();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ROLE_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.PERMISSION_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PERMISSION_CODE = Convert.ToString(values[3]);           

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
