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
    public class SP_GET_SURVEYLISTcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String ROUTE_CODE { get; set; }

        [DataMember]
        public String ROUTE_NAME { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }
        [DataMember]
        public String DISTRIBUTOR_NAME_CODE { get; set; }

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
        public Decimal SURVEY_STATUS { get; set; }

        [DataMember]
        public Decimal SURVEY_FOR { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_SURVEYLISTcls entity = new SP_GET_SURVEYLISTcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ROUTE_CODE = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.ROUTE_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME_CODE = Convert.ToString(values[4]); 

            if (values[5].GetType() != typeof(System.DBNull))
                entity.SURVEYLIST_ID = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTORID = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.RSOID = Convert.ToDecimal(values[7]);

            

            if (values[8].GetType() != typeof(System.DBNull))
                entity.ROUTEID = Convert.ToDecimal(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.TITLE = Convert.ToString(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.DESCRIPTION = Convert.ToString(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.START_DATETIME = Convert.ToDateTime(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.END_DATETIME = Convert.ToDateTime(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[14]);  

            if (values[15].GetType() != typeof(System.DBNull))
                entity.SURVEY_STATUS = Convert.ToDecimal(values[15]);

            if (values[16].GetType() != typeof(System.DBNull))
                entity.SURVEY_FOR = Convert.ToDecimal(values[16]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
