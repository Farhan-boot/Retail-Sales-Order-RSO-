using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class SP_INS_UPD_SURVEY_DETAIL_Q_ANScls : ObjectMakerFromOracleSP.ISpClassEntity
    {
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

        [DataMember]
        public Decimal SURVEY_DETAIL_AID { get; set; }
        [DataMember]
        public Decimal SURVEY_DETAIL_DELANSID { get; set; }

        [DataMember]
        public Decimal SURVEY_QID { get; set; }

        [DataMember]
        public string ANSWER { get; set; }

        [DataMember]
        public Decimal SURVEY_Detail_QA_ID { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_INS_UPD_SURVEY_DETAIL_Q_ANScls entity = new SP_INS_UPD_SURVEY_DETAIL_Q_ANScls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.SURVEY_Detail_QA_ID = Convert.ToDecimal(values[0]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
