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
    public class SP_INS_UPD_RSO_APPS_INBOXcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal TOTAL_VISIT { get; set; }

        [DataMember]
        public Decimal IS_PENDING { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public DateTime ADMIN_VISIT_DATE { get; set; }

        [DataMember]
        public String NOTICE_INFO { get; set; }

        [DataMember]
        public DateTime IN_DATE { get; set; }

        [DataMember]
        public Decimal APPS_INBOX_ID { get; set; }

        [DataMember]
        public Decimal NOTICE_TYPE { get; set; }

        [DataMember]
        public Decimal RSO_ID { get; set; }

        [DataMember]
        public Decimal ADMIN_ID { get; set; }

        [DataMember]
        public string DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public string DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public string RSO_CODE { get; set; }

        [DataMember]
        public string RSO_NAME { get; set; }

        [DataMember]
        public decimal TOTAL_RECORD { get; set; }

        [DataMember]
        public decimal ROW_NUMBER { get; set; }

        [DataMember]
        public String NOTICE_TYPE_STR { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_INS_UPD_RSO_APPS_INBOXcls entity = new SP_INS_UPD_RSO_APPS_INBOXcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.APPS_INBOX_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.IN_DATE = Convert.ToDateTime(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.NOTICE_TYPE = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.NOTICE_INFO = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.IS_PENDING = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.TOTAL_VISIT = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.ADMIN_ID = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.ADMIN_VISIT_DATE = Convert.ToDateTime(values[9]);
            if (values[10]!= null && values[10].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[10]);
            if (values[11]!= null && values[11].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[11]);
            if (values[12] != null && values[12].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[12]);
            if (values[13] != null && values[13].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[13]);
            if (values[14] != null && values[14].GetType() != typeof(System.DBNull))
                entity.TOTAL_RECORD = Convert.ToDecimal(values[14]);
            if (values[15] != null && values[15].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[15]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
