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
    public class GET_USER_TOKEN : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal USER_TOKEN_ID { get; set; }

        [DataMember]
        public string USER_ID { get; set; }

        [DataMember]
        public string TOKEN_ID { get; set; }

        [DataMember]
        public Decimal IS_EXPIRED { get; set; }

        [DataMember]
        public DateTime EXPIRED_AT { get; set; }

        public object MapToEntity(object[] values)
        {
            GET_USER_TOKEN entity = new GET_USER_TOKEN();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.USER_TOKEN_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.USER_ID = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.TOKEN_ID = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.IS_EXPIRED = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.EXPIRED_AT = Convert.ToDateTime(values[4]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
