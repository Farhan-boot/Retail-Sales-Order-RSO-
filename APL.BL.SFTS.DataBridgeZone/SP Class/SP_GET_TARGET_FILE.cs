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
    public class SP_GET_TARGET_FILE : ObjectMakerFromOracleSP.ISpClassEntity
    {     
        [DataMember]
        public Decimal UPLOAD_CODE { get; set; }

        [DataMember]
        public String MONTH_CODE { get; set; }

        [DataMember]
        public String MONTH_NAME { get; set; }

        [DataMember]
        public String TARGET_ITEM_CODE { get; set; }

        [DataMember]
        public String ITEM_NAME { get; set; }

        [DataMember]
        public Decimal APPLY_TYPE { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public Decimal TARGET_VALUE { get; set; }

        [DataMember]
        public DateTime SET_DATE { get; set; }

        [DataMember]
        public Decimal LOG { get; set; }

        [DataMember]
        public Decimal ROW_COUNT { get; set; }

        [DataMember]
        public Decimal TOTAL_TARGET_VALUE { get; set; }

        [DataMember]
        public String APPLY_SUB_TYPE { get; set; }

        [DataMember]
        public String STAFF_NAME { get; set; }

        [DataMember]
        public String REGION { get; set; }

        [DataMember]
        public String ZONE { get; set; }

        [DataMember]
        public Decimal APPLY_SUB_TYPE_ID { get; set; }

        [DataMember]
        public String STAFF_CODE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_TARGET_FILE entity = new SP_GET_TARGET_FILE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.UPLOAD_CODE = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.MONTH_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MONTH_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_CODE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.ITEM_NAME = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.APPLY_TYPE = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.TARGET_VALUE = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.SET_DATE = Convert.ToDateTime(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.LOG = Convert.ToDecimal(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.ROW_COUNT = Convert.ToDecimal(values[11]);
            if (values[12].GetType() != typeof(System.DBNull))
                entity.TOTAL_TARGET_VALUE = Convert.ToDecimal(values[12]);
            if (values[13].GetType() != typeof(System.DBNull))
                entity.APPLY_SUB_TYPE = Convert.ToString(values[13]);
            if (values[14].GetType() != typeof(System.DBNull))
                entity.STAFF_NAME = Convert.ToString(values[14]);
            if (values[15].GetType() != typeof(System.DBNull))
                entity.REGION = Convert.ToString(values[15]);
            if (values[16].GetType() != typeof(System.DBNull))
                entity.ZONE = Convert.ToString(values[16]);
            if (values[17].GetType() != typeof(System.DBNull))
                entity.APPLY_SUB_TYPE_ID = Convert.ToDecimal(values[17]);
            if (values[18].GetType() != typeof(System.DBNull))
                entity.STAFF_CODE = Convert.ToString(values[18]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
