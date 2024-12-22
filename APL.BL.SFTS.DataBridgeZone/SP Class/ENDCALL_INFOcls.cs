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
    public class ENDCALL_INFOcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ENDCALL_INFO_ID { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public Decimal RSO_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public DateTime DATE_TIME { get; set; }

        [DataMember]
        public String CALL_NOTE { get; set; }

        [DataMember]
        public DateTime UPDATE_DATE { get; set; }

        [DataMember]
        public Decimal UPDATE_BY { get; set; }

        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public Decimal CALL_STATUS { get; set; }

        [DataMember]
        public Decimal ROW_NUMBER { get; set; }

        [DataMember]
        public Decimal TOTAL_RECORD { get; set; }


        public object MapToEntity(object[] values)
        {
            ENDCALL_INFOcls entity = new ENDCALL_INFOcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ENDCALL_INFO_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.DATE_TIME = Convert.ToDateTime(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.CALL_NOTE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.UPDATE_DATE = Convert.ToDateTime(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.UPDATE_BY = Convert.ToDecimal(values[7]);

            if (values[8] !=null && values[8].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[8]);
            if (values[9] != null && values[9].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[9]);
            if (values[10] != null && values[10].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[10]);

            if (values[11] != null && values[11].GetType() != typeof(System.DBNull))
                entity.CALL_STATUS = Convert.ToDecimal(values[11]);
            if (values[12] != null && values[12].GetType() != typeof(System.DBNull))
                entity.ROW_NUMBER = Convert.ToDecimal(values[12]);
            if (values[13] != null && values[13].GetType() != typeof(System.DBNull))
                entity.TOTAL_RECORD = Convert.ToDecimal(values[13]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
