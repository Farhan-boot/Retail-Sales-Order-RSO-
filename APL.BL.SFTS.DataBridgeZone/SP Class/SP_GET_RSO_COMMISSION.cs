using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RSO_COMMISSION : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String COMMISSION_MONTH { get; set; }
        
        [DataMember]
        public String COMMISSION_TYPE { get; set; }

        [DataMember]
        public String COMMISSION_AMOUNT { get; set; }

        [DataMember]
        public String DISBURSEMENT_DATE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_COMMISSION entity = new SP_GET_RSO_COMMISSION();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.COMMISSION_MONTH = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.COMMISSION_TYPE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.COMMISSION_AMOUNT = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.DISBURSEMENT_DATE = Convert.ToString(values[5]);  

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
