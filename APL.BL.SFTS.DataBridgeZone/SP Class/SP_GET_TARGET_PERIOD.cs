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
    public class SP_GET_TARGET_PERIOD : ObjectMakerFromOracleSP.ISpClassEntity
    {     
        [DataMember]
        public Decimal TARGET_PERIOD_ID { get; set; }

        [DataMember]
        public String TARGET_PERIOD_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_TARGET_PERIOD entity = new SP_GET_TARGET_PERIOD();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.TARGET_PERIOD_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TARGET_PERIOD_NAME = Convert.ToString(values[1]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
