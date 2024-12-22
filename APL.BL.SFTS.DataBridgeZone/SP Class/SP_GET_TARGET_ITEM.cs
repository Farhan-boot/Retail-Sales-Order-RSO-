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
    public class SP_GET_TARGET_ITEM : ObjectMakerFromOracleSP.ISpClassEntity
    {     
        [DataMember]
        public Decimal TARGET_ITEM_ID { get; set; }

        [DataMember]
        public String TARGET_ITEM_CODE { get; set; }

        [DataMember]
        public String TARGET_ITEM_NAME { get; set; }

        [DataMember]
        public String TARGET_ITEM_NAME_CODE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_TARGET_ITEM entity = new SP_GET_TARGET_ITEM();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_NAME_CODE = Convert.ToString(values[3]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
