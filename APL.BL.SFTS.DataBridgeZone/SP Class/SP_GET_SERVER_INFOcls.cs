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
    public class SP_GET_SERVER_INFOcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public DateTime SERVER_DATE { get; set; }

        [DataMember]
        public string SERVER_TIME { get; set; }
        [DataMember]
        public string SERVER_DATE_TIME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_SERVER_INFOcls entity = new SP_GET_SERVER_INFOcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.SERVER_DATE = Convert.ToDateTime(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.SERVER_TIME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.SERVER_DATE_TIME = Convert.ToString(values[2]);
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
