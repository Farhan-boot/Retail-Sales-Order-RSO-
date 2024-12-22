using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class SP_INS_UPD_SURVEY_LISTcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal SURVEYLIST_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTORID { get; set; }


        [DataMember]
        public Decimal RSOID { get; set; }


        [DataMember]
        public Decimal ROUTEID { get; set; }        

        [DataMember]
        public String TITLE { get; set; }

        [DataMember]
        public String DESCRIPTION { get; set; }


        [DataMember]
        public DateTime START_DATETIME { get; set; }

        [DataMember]
        public DateTime END_DATETIME { get; set; }

        [DataMember]
        public Decimal CREATE_BY { get; set; }

        [DataMember]
        public DateTime CREATE_DATE { get; set; }

        [DataMember]
        public Decimal SURVEY_LIST_ID { get; set; }

		[DataMember]
		public Decimal SURVEY_FOR { get; set; }


		public object MapToEntity(object[] values)
        {
            SP_INS_UPD_SURVEY_LISTcls entity = new SP_INS_UPD_SURVEY_LISTcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.SURVEY_LIST_ID = Convert.ToDecimal(values[0]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
