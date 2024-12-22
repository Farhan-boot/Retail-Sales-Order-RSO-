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
    public class GET_TARGET_ITEM_APPLY_TO : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal TARGET_ITEM_APPLY_ID { get; set; }

        [DataMember]
        public Decimal TARGET_ITEM_ID { get; set; }

        [DataMember]
        public Decimal CHANNEL_TYPE_ID { get; set; }

        [DataMember]
        public String CHANNEL_TYPE_NAME { get; set; }

        [DataMember]
        public Decimal TARGET_ENTITY_TYPE { get; set; }

        [DataMember]
        public String ENTITY_TYPE_NAME { get; set; }

        [DataMember]
        public Decimal STAFF_TYPE_ID { get; set; }

        [DataMember]
        public String STAFF_TYPE_NAME { get; set; }

        [DataMember]
        public Decimal CENTER_TYPE_ID { get; set; }

        [DataMember]
        public String CENTER_TYPE_NAME { get; set; }

        //[DataMember]
        //public Decimal IS_ACTIVE { get; set; }

        public object MapToEntity(object[] values)
        {
            GET_TARGET_ITEM_APPLY_TO entity = new GET_TARGET_ITEM_APPLY_TO();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_APPLY_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TARGET_ITEM_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.CHANNEL_TYPE_ID = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.CHANNEL_TYPE_NAME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.TARGET_ENTITY_TYPE = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.ENTITY_TYPE_NAME = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.STAFF_TYPE_ID = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.STAFF_TYPE_NAME = Convert.ToString(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.CENTER_TYPE_ID = Convert.ToDecimal(values[8]);
            if (values[9].GetType() != typeof(System.DBNull))
                entity.CENTER_TYPE_NAME = Convert.ToString(values[9]);
            //if (values[10].GetType() != typeof(System.DBNull))
            //    entity.IS_ACTIVE = Convert.ToDecimal(values[10]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
