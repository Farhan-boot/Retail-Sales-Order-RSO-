using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_ALL_FEEDBACK_QUESTION : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal FEEDBACK_QUESTION_ID { get; set; }
               
        [DataMember]
        public String QUESTION_TEXT { get; set; }

        [DataMember]
        public Decimal DISPLAY_ORDER { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_ALL_FEEDBACK_QUESTION entity = new SP_GET_ALL_FEEDBACK_QUESTION();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.FEEDBACK_QUESTION_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.QUESTION_TEXT = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISPLAY_ORDER = Convert.ToDecimal(values[2]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
