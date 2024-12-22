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
    public class SP_GET_ROUTE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ROUTE_ID { get; set; }

        [DataMember]
        public String ROUTE_NAME { get; set; }

        [DataMember]
        public String ROUTE_CODE { get; set; }

   
        public object MapToEntity(object[] values)
        {
            SP_GET_ROUTE entity = new SP_GET_ROUTE();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.ROUTE_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.ROUTE_CODE = Convert.ToString(values[2]);
           
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
