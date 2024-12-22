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
    public class GET_ZONE : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public Decimal ZONE_ID { get; set; }

        [DataMember]
        public String ZONE_NAME { get; set; }

        [DataMember]
        public String ZONE_CODE_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            GET_ZONE entity = new GET_ZONE();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ZONE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.ZONE_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.ZONE_CODE_NAME = Convert.ToString(values[2]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
