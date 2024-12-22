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
    public class SP_GET_EVENT_INFO : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal EVENT_ID { get; set; }

        [DataMember]
        public String EVENT_NAME { get; set; }

        [DataMember]
        public String NOTE { get; set; }

        [DataMember]
        public String IS_ACTIVE { get; set; }

        [DataMember]
        public Boolean IS_NATIONAL_EVENT { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_EVENT_INFO entity = new SP_GET_EVENT_INFO();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.EVENT_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.EVENT_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.NOTE = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.IS_NATIONAL_EVENT = Convert.ToBoolean(values[4]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
