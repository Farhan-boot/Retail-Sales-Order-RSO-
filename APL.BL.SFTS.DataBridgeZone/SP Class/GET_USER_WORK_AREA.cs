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
    public class GET_USER_WORK_AREA : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public Decimal USER_ID { get; set; }

        [DataMember]
        public Decimal MARKET_AREA_TYPE_ID { get; set; }

        public object MapToEntity(object[] values)
        {
            GET_USER_WORK_AREA entity = new GET_USER_WORK_AREA();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.USER_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.MARKET_AREA_TYPE_ID = Convert.ToDecimal(values[2]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
