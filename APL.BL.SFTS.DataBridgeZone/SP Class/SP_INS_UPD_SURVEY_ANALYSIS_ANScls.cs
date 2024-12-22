using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class SP_INS_UPD_SURVEY_ANALYSIS_ANScls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal SURVEYANALYSIS_ANSID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTORID { get; set; }


        [DataMember]
        public Decimal RSOID { get; set; }


        [DataMember]
        public Decimal SURVEYLIST_ID { get; set; }

        [DataMember]
        public Decimal SURVEYDETAIL_QID { get; set; }

        [DataMember]
        public Decimal SURVEYDETAIL_AID { get; set; }

        [DataMember]
        public Decimal OPTAIN_POINT { get; set; }

        
        [DataMember]
        public DateTime SUBMIT_DATE { get; set; }

        [DataMember]
        public string ADMIN_REMARK { get; set; }
        
        [DataMember]
        public Decimal outSURVEYANALYSIS_ANSID { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_INS_UPD_SURVEY_ANALYSIS_ANScls entity = new SP_INS_UPD_SURVEY_ANALYSIS_ANScls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.outSURVEYANALYSIS_ANSID = Convert.ToDecimal(values[0]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
