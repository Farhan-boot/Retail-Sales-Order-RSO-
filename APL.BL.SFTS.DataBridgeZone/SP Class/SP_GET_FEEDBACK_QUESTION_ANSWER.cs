using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_FEEDBACK_QUESTION_ANSWER : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String QUESTION_TEXT { get; set; }

        [DataMember]
        public Decimal RATING { get; set; }

        [DataMember]
        public String OBSERVATION { get; set; }

        [DataMember]
        public String ACTIONPOINT { get; set; }      
        
        public object MapToEntity(object[] values)
        {
            SP_GET_FEEDBACK_QUESTION_ANSWER entity = new SP_GET_FEEDBACK_QUESTION_ANSWER();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.QUESTION_TEXT = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RATING = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.OBSERVATION = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.ACTIONPOINT = Convert.ToString(values[4]);
           
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
