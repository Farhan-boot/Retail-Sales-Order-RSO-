using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_ALL_SURVEY_LIST_QUE_ANScls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal SURVEY_LIST_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTORID { get; set; }

        [DataMember]
        public Decimal RSOID { get; set; }

        [DataMember]
        public Decimal ROUTEID { get; set; }

        [DataMember]
        public String SURVEY_TITLE { get; set; }

        [DataMember]
        public String SURVEY_DESCRIPTION { get; set; }

        [DataMember]
        public DateTime SURVEY_START_DATETIME { get; set; }

        [DataMember]
        public DateTime SURVEY_END_DATETIME { get; set; }

        [DataMember]
        public Decimal SURVEY_CREATE_BY { get; set; }

        [DataMember]
        public DateTime SURVEY_CREATE_DATE { get; set; }

        [DataMember]
        public Decimal SURVEY_DETAIL_Q_ID { get; set; }

        [DataMember]
        public Decimal SDQ_POINT { get; set; }

        [DataMember]
        public String SDQ_QUESTION { get; set; }

        [DataMember]
        public String SDQ_NOTE { get; set; }

        [DataMember]
        public Decimal SURVEY_DETAIL_ANS_ID { get; set; }

        [DataMember]
        public String SDA_ANSWER { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_ALL_SURVEY_LIST_QUE_ANScls entity = new SP_GET_ALL_SURVEY_LIST_QUE_ANScls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.SURVEY_LIST_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTORID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSOID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.ROUTEID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.SURVEY_TITLE = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.SURVEY_DESCRIPTION = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.SURVEY_START_DATETIME = Convert.ToDateTime(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.SURVEY_END_DATETIME = Convert.ToDateTime(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.SURVEY_CREATE_BY = Convert.ToDecimal(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.SURVEY_CREATE_DATE = Convert.ToDateTime(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.SURVEY_DETAIL_Q_ID = Convert.ToDecimal(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.SDQ_POINT = Convert.ToDecimal(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.SDQ_QUESTION = Convert.ToString(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.SDQ_NOTE = Convert.ToString(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.SURVEY_DETAIL_ANS_ID = Convert.ToDecimal(values[14]);

             if (values[15].GetType() != typeof(System.DBNull))
                 entity.SDA_ANSWER = Convert.ToString(values[15]);
            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
