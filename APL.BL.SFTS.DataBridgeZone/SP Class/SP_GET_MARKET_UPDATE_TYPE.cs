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
    public class SP_GET_MARKET_UPDATE_TYPE : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String NAME { get; set; }

        [DataMember]
        public String IS_ACTIVE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_MARKET_UPDATE_TYPE entity = new SP_GET_MARKET_UPDATE_TYPE();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToString(values[2]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
