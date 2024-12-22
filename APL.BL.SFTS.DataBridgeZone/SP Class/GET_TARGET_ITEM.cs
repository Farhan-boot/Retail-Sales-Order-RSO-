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
    public class GET_TARGET_ITEM : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal TARGET_ITEM_ID { get; set; }

        [DataMember]
        public String TARGET_ITEM_CODE { get; set; }

        [DataMember]
        public String TARGET_ITEM_NAME { get; set; }

        [DataMember]
        public Decimal IS_ACTIVE { get; set; }

        [DataMember]
        public String UNIT_NAME { get; set; }

        [DataMember]
        public String ACTIVE_STATUS { get; set; }
        

        public object MapToEntity(object[] values)
        {
            GET_TARGET_ITEM entity = new GET_TARGET_ITEM();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.UNIT_NAME = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.ACTIVE_STATUS = Convert.ToString(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
