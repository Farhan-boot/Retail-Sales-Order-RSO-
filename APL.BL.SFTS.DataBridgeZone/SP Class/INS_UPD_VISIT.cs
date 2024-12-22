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
    public class INS_UPD_VISIT : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal VISIT_ID { get; set; }

        public object MapToEntity(object[] values)
        {
            INS_UPD_VISIT entity = new INS_UPD_VISIT();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.VISIT_ID = Convert.ToDecimal(values[0]);

          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
