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
    public class SP_GET_TERGAT_FOR_DIST : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal TARGET_ID { get; set; }

        [DataMember]
        public decimal TARGET_ITEM_ID { get; set; }

        [DataMember]
        public decimal TARGET_PERIOD_ID { get; set; }

        [DataMember]
        public DateTime SET_DATE { get; set; }

        [DataMember]
        public Decimal CREATED_BY_USER { get; set; }

        [DataMember]
        public Decimal IS_ACTIVE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_TERGAT_FOR_DIST entity = new SP_GET_TERGAT_FOR_DIST();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.TARGET_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.TARGET_PERIOD_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.SET_DATE = Convert.ToDateTime(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.CREATED_BY_USER = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.IS_ACTIVE = Convert.ToDecimal(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
