using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_SAVE_RESULT_WITH_ERROR_CODE : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public Decimal SAVED_ID { get; set; }

        [DataMember]
        public Decimal ERROR_ID { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_SAVE_RESULT_WITH_ERROR_CODE entity = new SP_GET_SAVE_RESULT_WITH_ERROR_CODE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.SAVED_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ERROR_ID = Convert.ToDecimal(values[1]);
                 
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
