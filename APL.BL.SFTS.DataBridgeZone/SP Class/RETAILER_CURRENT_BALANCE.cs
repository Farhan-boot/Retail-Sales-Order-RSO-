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
    public class RETAILER_CURRENT_BALANCE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public DateTime LAST_ISSUR_DATE { get; set; }

        [DataMember]
        public Decimal AMOUNT { get; set; }
     

        public object MapToEntity(object[] values)
        {
            RETAILER_CURRENT_BALANCE entity = new RETAILER_CURRENT_BALANCE();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.LAST_ISSUR_DATE = Convert.ToDateTime(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.AMOUNT = Convert.ToDecimal(values[1]);
                  
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
