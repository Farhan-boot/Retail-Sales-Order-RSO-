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
    public class SP_GET_SURVEYANALYSYS_ANScls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String TITLE { get; set; }
        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String RSO_NAME { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }
        [DataMember]
        public String DISTRIBUTOR_NAME_CODE { get; set; }

        [DataMember]
        public string QUESTION { get; set; }

        [DataMember]
        public string ANSWER { get; set; }

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

        public object MapToEntity(object[] values)
        {
            SP_GET_SURVEYANALYSYS_ANScls entity = new SP_GET_SURVEYANALYSYS_ANScls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TITLE = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME_CODE = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.QUESTION = Convert.ToString(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.ANSWER = Convert.ToString(values[7]);


            if (values[8].GetType() != typeof(System.DBNull))
                entity.SURVEYANALYSIS_ANSID = Convert.ToDecimal(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTORID = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.RSOID = Convert.ToDecimal(values[10]);

           
            if (values[11].GetType() != typeof(System.DBNull))
                entity.SURVEYLIST_ID = Convert.ToDecimal(values[11]);           

            if (values[12].GetType() != typeof(System.DBNull))
                entity.SURVEYDETAIL_QID = Convert.ToDecimal(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.SURVEYDETAIL_AID = Convert.ToDecimal(values[13]);            

            if (values[14].GetType() != typeof(System.DBNull))
                entity.OPTAIN_POINT = Convert.ToDecimal(values[14]);

            if (values[15].GetType() != typeof(System.DBNull))
                entity.SUBMIT_DATE = Convert.ToDateTime(values[15]);

            if (values[16].GetType() != typeof(System.DBNull))
                entity.ADMIN_REMARK = Convert.ToString(values[16]);
            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
