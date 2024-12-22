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
    public class SP_GET_SURVEYANSWER_LISTcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String QUESTION { get; set; }

        [DataMember]
        public Decimal SURVEY_DETAIL_AID { get; set; }
        [DataMember]
        public Decimal SURVEY_DETAIL_QID { get; set; }
        [DataMember]
        public string ANSWER { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_SURVEYANSWER_LISTcls entity = new SP_GET_SURVEYANSWER_LISTcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.QUESTION = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.SURVEY_DETAIL_AID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.SURVEY_DETAIL_QID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.ANSWER = Convert.ToString(values[3]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
