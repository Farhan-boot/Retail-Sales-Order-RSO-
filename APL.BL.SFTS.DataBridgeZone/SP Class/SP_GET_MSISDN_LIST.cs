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
    public class SP_GET_MSISDN_LIST : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String ACTIVATION_DATE { get; set; }

        [DataMember]
        public String RETAILER_CODE { get; set; }

        [DataMember]
        public String MSISDN { get; set; }

        [DataMember]
        public Decimal RECHARGE_MSISDN_AMOUNT { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_MSISDN_LIST entity = new SP_GET_MSISDN_LIST();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ACTIVATION_DATE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MSISDN = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.RECHARGE_MSISDN_AMOUNT = Convert.ToDecimal(values[3]);
            
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
