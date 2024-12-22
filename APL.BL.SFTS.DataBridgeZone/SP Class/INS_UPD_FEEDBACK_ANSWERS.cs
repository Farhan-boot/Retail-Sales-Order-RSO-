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
    public class INS_UPD_FEEDBACK_ANSWERS : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public Decimal VISIT_ID { get; set; }

        [DataMember]
        public Decimal QUESTION_ID { get; set; }

        [DataMember]
        public Decimal RATING { get; set; }

        [DataMember]
        public string OBSERVATION { get; set; }

        [DataMember]
        public string ACTIONPOINT { get; set; }

        public object MapToEntity(object[] values)
        {
            INS_UPD_FEEDBACK_ANSWERS entity = new INS_UPD_FEEDBACK_ANSWERS();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.VISIT_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.QUESTION_ID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.RATING = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.OBSERVATION = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.ACTIONPOINT = Convert.ToString(values[5]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
