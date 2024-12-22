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
    public class SP_GET_FOOTSTEP_EXPORT2 : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public string BTS_CODE { get; set; }
        [DataMember]
        public string BTS_INFO { get; set; }
        [DataMember]
        public string ADDRESS { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_FOOTSTEP_EXPORT2 entity = new SP_GET_FOOTSTEP_EXPORT2();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.BTS_CODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.BTS_INFO = Convert.ToString(values[1]); 
            if (values[2].GetType() != typeof(System.DBNull))
                entity.ADDRESS = Convert.ToString(values[2]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

