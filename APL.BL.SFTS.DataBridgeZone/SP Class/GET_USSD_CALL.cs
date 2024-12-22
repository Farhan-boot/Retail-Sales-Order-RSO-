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
    public class GET_USSD_CALL : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public Decimal USSD_CALL_STATUS { get; set; }


        public object MapToEntity(object[] values)
        {
            GET_USSD_CALL entity = new GET_USSD_CALL();


            if (values[0] != null && values[0].GetType() != typeof(System.DBNull))
                entity.USSD_CALL_STATUS = Convert.ToDecimal(values[0]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
