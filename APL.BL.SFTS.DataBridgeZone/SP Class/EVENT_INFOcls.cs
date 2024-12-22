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
    public class EVENT_INFOcls : ObjectMakerFromOracleSP.ISpClassEntity
    {       
        [DataMember]
        public Decimal EVENT_INFO_ID { get; set; }

        [DataMember]
        public String EVENT_INFO_NAME { get; set; }

        [DataMember]
        public String EVENT_INFO_NOTE { get; set; }

         [DataMember]
        public Decimal IS_ACTIVE { get; set; }

        [DataMember]
        public Decimal CREATE_BY { get; set; }

        [DataMember]
        public DateTime CREATE_DATE { get; set; }
      
        public object MapToEntity(object[] values)
        {
            EVENT_INFOcls entity = new EVENT_INFOcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.EVENT_INFO_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.EVENT_INFO_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.EVENT_INFO_NOTE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.CREATE_BY = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.CREATE_DATE = Convert.ToDateTime(values[5]);     

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
