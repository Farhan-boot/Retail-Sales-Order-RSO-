using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.SP_Class
{
    [Serializable()]
    [DataContract]
    public class SP_FF_GET_TARGET_PERIOD : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public decimal ID { get; set; }
        [DataMember]
        public string PERIOD_NAME { get; set; }
        public object MapToEntity(object[] values)
        {
            SP_FF_GET_TARGET_PERIOD entity = new SP_FF_GET_TARGET_PERIOD();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.PERIOD_NAME = Convert.ToString(values[1]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
