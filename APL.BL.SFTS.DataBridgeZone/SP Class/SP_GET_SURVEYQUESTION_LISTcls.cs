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
    public class SP_GET_SURVEYQUESTION_LISTcls : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public String TITLE { get; set; }
        [DataMember]
        public Decimal SURVEY_DETAIL_QID { get; set; }

        [DataMember]
        public Decimal SURVEY_LIST_ID { get; set; }


        [DataMember]
        public Decimal POINT { get; set; }

        [DataMember]
        public String QUESTION { get; set; }

        [DataMember]
        public String NOTE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_SURVEYQUESTION_LISTcls entity = new SP_GET_SURVEYQUESTION_LISTcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TITLE = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.SURVEY_DETAIL_QID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.SURVEY_LIST_ID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.POINT = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.QUESTION = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.NOTE = Convert.ToString(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
