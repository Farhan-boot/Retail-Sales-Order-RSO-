using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_FEEDBACK_QUESTION : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal FEEDBACK_QUESTION_ID { get; set; }
               
        [DataMember]
        public String QUESTION_TEXT { get; set; }

        [DataMember]
        public Decimal RATTING { get; set; }

        [DataMember]
        public String PREV_OBSERVATION { get; set; }

        [DataMember]
        public String PREV_ACTIONPOINT { get; set; }

        [DataMember]
        public String NEW_OBSERVATION { get; set; }

        [DataMember]
        public String NEW_ACTIONPOINT { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_FEEDBACK_QUESTION entity = new SP_GET_FEEDBACK_QUESTION();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.FEEDBACK_QUESTION_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.QUESTION_TEXT = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RATTING = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PREV_OBSERVATION = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.PREV_ACTIONPOINT = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.NEW_OBSERVATION = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.NEW_ACTIONPOINT = Convert.ToString(values[6]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
