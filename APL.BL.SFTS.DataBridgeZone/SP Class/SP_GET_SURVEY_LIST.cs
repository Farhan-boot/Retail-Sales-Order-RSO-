using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_SURVEY_LIST : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public Decimal SURVEY_LIST_ID { get; set; }

        [DataMember]
        public String SURVEY_NAME { get; set; }

        [DataMember]
        public String DESCRIPTION { get; set; }

		[DataMember]
		public String ISATTENT { get; set; }

		

		public object MapToEntity(object[] values)
        {
            SP_GET_SURVEY_LIST entity = new SP_GET_SURVEY_LIST();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.SURVEY_LIST_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.SURVEY_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DESCRIPTION = Convert.ToString(values[2]);
			if (values[3].GetType() != typeof(System.DBNull))
				entity.ISATTENT = Convert.ToString(values[3]);


			return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
