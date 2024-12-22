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
    public class SP_GET_MONTH : ObjectMakerFromOracleSP.ISpClassEntity
    {     
        [DataMember]
        public Decimal MONTH_ID { get; set; }

        [DataMember]
        public String MONTH_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_MONTH entity = new SP_GET_MONTH();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.MONTH_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.MONTH_NAME = Convert.ToString(values[1]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
