using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_FEEDBACK_QUESTIONNAIRE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal QUESTIONNAIRE_ID { get; set; }

        [DataMember]
        public Decimal VISIT_TYPE_ID { get; set; }

        [DataMember]
        public String VISIT_TYPE_NAME { get; set; }

        [DataMember]
        public Decimal CENTER_TYPE_ID { get; set; }

        [DataMember]
        public String CENTER_TYPE_NAME { get; set; }

        [DataMember]
        public Decimal ENTITY_TYPE_ID { get; set; }

        [DataMember]
        public String ENTITY_TYPE_NAME { get; set; }

        [DataMember]
        public String IS_ACTIVE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_FEEDBACK_QUESTIONNAIRE entity = new SP_GET_FEEDBACK_QUESTIONNAIRE();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.QUESTIONNAIRE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.VISIT_TYPE_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.VISIT_TYPE_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.CENTER_TYPE_ID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.CENTER_TYPE_NAME = Convert.ToString(values[4]); 

            if (values[5].GetType() != typeof(System.DBNull))
                entity.ENTITY_TYPE_ID = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.ENTITY_TYPE_NAME = Convert.ToString(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToString(values[7]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
