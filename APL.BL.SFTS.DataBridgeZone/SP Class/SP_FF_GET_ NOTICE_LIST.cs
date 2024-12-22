using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.SP_Class
{
    [Serializable()]
    [DataContract]
    public class SP_FF_GET__NOTICE_LIST : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal NOTICE_ID { get; set; }

        [DataMember]
        public Decimal NOTICE_TYPE_ID { get; set; }

        [DataMember]
        public String NOTICE_TYPE { get; set; }

        [DataMember]
        public Decimal NOTICE_FOR_ID { get; set; }

        [DataMember]
        public String NOTICE_FOR { get; set; }

        [DataMember]
        public string FROM_DATE { get; set; }

        [DataMember]
        public string TO_DATE { get; set; }

        [DataMember]
        public String TITLE { get; set; }
        [DataMember]
        public String MESSAGE { get; set; }
        [DataMember]
        public String URL { get; set; }
        [DataMember]
        public String FILENAME { get; set; }
        [DataMember]
        public decimal IS_ACTIVE { get; set; }
        [DataMember]
        public decimal LAST_UPDATE_BY { get; set; }
        [DataMember]
        public DateTime LAST_UPDATE_AT { get; set; }
        [DataMember]
        public string DD_IDS { get; set; }
        [DataMember]
        public string DD_NAMES { get; set; }
        [DataMember]
        public string RE_IDS { get; set; }
        [DataMember]
        public string RE_NAMES { get; set; }
        [DataMember]
        public string NOTICE_TIMES { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_FF_GET__NOTICE_LIST entity = new SP_FF_GET__NOTICE_LIST();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.NOTICE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.NOTICE_TYPE_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.NOTICE_TYPE = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.NOTICE_FOR_ID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.NOTICE_FOR = Convert.ToString(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.FROM_DATE = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.TO_DATE = Convert.ToString(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.TITLE = Convert.ToString(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.MESSAGE = Convert.ToString(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.URL = Convert.ToString(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.FILENAME = Convert.ToString(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.LAST_UPDATE_BY = Convert.ToDecimal(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.LAST_UPDATE_AT = Convert.ToDateTime(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.DD_IDS = Convert.ToString(values[14]);

            if (values[15].GetType() != typeof(System.DBNull))
                entity.DD_NAMES = Convert.ToString(values[15]).Replace(",,","");

            if (values[16].GetType() != typeof(System.DBNull))
                entity.RE_IDS = Convert.ToString(values[16]);

            if (values[17].GetType() != typeof(System.DBNull))
                entity.RE_NAMES = Convert.ToString(values[17]).Replace(",,", "");

            if (values[18].GetType() != typeof(System.DBNull))
                entity.NOTICE_TIMES = Convert.ToString(values[18]).Replace(",,", "");


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
