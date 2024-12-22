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
    public class GET_ALL_ZONE : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public Decimal Id { get; set; }

        [DataMember]
        public String ZONE_NAME { get; set; }

        [DataMember]
        public String Label { get; set; }

        public object MapToEntity(object[] values)
        {
            GET_ALL_ZONE entity = new GET_ALL_ZONE();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.Id = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.ZONE_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.Label = Convert.ToString(values[2]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
