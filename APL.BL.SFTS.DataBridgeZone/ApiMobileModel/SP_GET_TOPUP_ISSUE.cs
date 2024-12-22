using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone.ApiMobileModel
{
    [Serializable()]
    [DataContract]
    public class SP_GET_TOPUP_ISSUE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ISSUE_ID { get; set; }

        [DataMember]
        public String ISSUE_DATE { get; set; }

        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public Decimal ISSUED_BY_USER_ID { get; set; }

        [DataMember]
        public String ISSUED_BY_RSO_CODE { get; set; }

        [DataMember]
        public String ISSUED_BY_RSO_NAME { get; set; }

        [DataMember]
        public Decimal TOPUP_AMOUNT { get; set; }

        [DataMember]
        public String ISSUE_STATUS { get; set; }

        [DataMember]
        public String ISSUE_STATUS_DESCRIPTION { get; set; }

        [DataMember]
        public String EXECUTION_ERR_MESSAGE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_TOPUP_ISSUE entity = new SP_GET_TOPUP_ISSUE();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ISSUE_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.ISSUE_DATE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.ISSUED_BY_USER_ID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.ISSUED_BY_RSO_CODE = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.ISSUED_BY_RSO_NAME = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.TOPUP_AMOUNT = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.ISSUE_STATUS = Convert.ToString(values[9]);
            if (values[10].GetType() != typeof(System.DBNull))
                entity.ISSUE_STATUS_DESCRIPTION = Convert.ToString(values[10]);
            if (values[11].GetType() != typeof(System.DBNull))
                entity.EXECUTION_ERR_MESSAGE = Convert.ToString(values[11]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
