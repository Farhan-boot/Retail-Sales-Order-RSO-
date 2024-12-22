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
    public class SP_GET_STAFF_TARGET : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal TARGET_ID { get; set; }

        [DataMember]
        public Decimal TARGET_ITEM_ID { get; set; }

        [DataMember]
        public String TARGET_ITEM_NAME { get; set; }

        [DataMember]
        public Decimal TARGET_PERIOD_ID { get; set; }

        [DataMember]
        public String PERIOD_NAME { get; set; }

        [DataMember]
        public String SET_DATE { get; set; }

        [DataMember]
        public Decimal VERSION { get; set; }

        [DataMember]
        public Decimal TOTAL_TARGET_VALUE { get; set; }

        [DataMember]
        public String APPROVE_STATUS { get; set; }

        [DataMember]
        public String REVISION_VALID_UP_TO { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_STAFF_TARGET entity = new SP_GET_STAFF_TARGET();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TARGET_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.TARGET_PERIOD_ID = Convert.ToDecimal(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.PERIOD_NAME = Convert.ToString(values[4]); 

            if (values[5].GetType() != typeof(System.DBNull))
                entity.SET_DATE = Convert.ToString(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.VERSION = Convert.ToDecimal(values[6]);

            if (values[7].GetType() != typeof(System.DBNull))
                entity.TOTAL_TARGET_VALUE = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.APPROVE_STATUS = Convert.ToString(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.REVISION_VALID_UP_TO = Convert.ToString(values[9]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
