using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RETAILER_SAF : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String PREPAID_ACTIVATION_THIS_MONTH { get; set; }
        
        [DataMember]
        public String PREPAID_SAF_PENDING_THIS_MONTH { get; set; }

        [DataMember]
        public String POSTPAID_ACTIVATION_THIS_MONTH { get; set; }

        [DataMember]
        public String POSTPAID_SAF_PENDING_THIS_MONTH { get; set; }

        [DataMember]
        public String TOTAL_SAF_PENDING_PREPAID { get; set; }

        [DataMember]
        public String TOTAL_SAF_PENDING_POSTPAID { get; set; }

       
        public object MapToEntity(object[] values)
        {
            SP_GET_RETAILER_SAF entity = new SP_GET_RETAILER_SAF();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.PREPAID_ACTIVATION_THIS_MONTH = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.PREPAID_SAF_PENDING_THIS_MONTH = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.POSTPAID_ACTIVATION_THIS_MONTH = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.POSTPAID_SAF_PENDING_THIS_MONTH = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.TOTAL_SAF_PENDING_PREPAID = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.TOTAL_SAF_PENDING_POSTPAID = Convert.ToString(values[8]);          

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
