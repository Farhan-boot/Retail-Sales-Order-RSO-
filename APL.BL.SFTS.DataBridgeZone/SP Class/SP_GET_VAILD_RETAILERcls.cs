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
    public class SP_GET_VAILD_RETAILERcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal RETAILER_ID { get; set; }

        [DataMember]
        public Decimal RSO_ID { get; set; }

        [DataMember]
        public Decimal RETAILER_CODE { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_GET_VAILD_RETAILERcls entity = new SP_GET_VAILD_RETAILERcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.RETAILER_ID = Convert.ToDecimal(values[0]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
