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
    public class SP_GET_TARGET_SETUP : ObjectMakerFromOracleSP.ISpClassEntity
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
        public Decimal TARGET_FOR_ID { get; set; }

        [DataMember]
        public String TARGET_FOR { get; set; }

        [DataMember]
        public Decimal STAFF_TYPE_ID { get; set; }

        [DataMember]
        public String STAFF_TYPE_NAME { get; set; }

        [DataMember]
        public String REVISION_VALID_UP_TO { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_TARGET_SETUP entity = new SP_GET_TARGET_SETUP();

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
                entity.TARGET_FOR_ID = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.TARGET_FOR = Convert.ToString(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.STAFF_TYPE_ID = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.STAFF_TYPE_NAME = Convert.ToString(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.REVISION_VALID_UP_TO = Convert.ToString(values[11]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
