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
    public class SP_GET_DISTRIBUTOR_TARGET : ObjectMakerFromOracleSP.ISpClassEntity
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
        public Decimal TARGET_DETAIL_VERSION { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public Decimal TARGET_VALUE { get; set; }

        [DataMember]
        public Decimal ACHIVED_VALUE { get; set; }

        [DataMember]
        public Decimal TARGET_DETAIL_ID { get; set; }

        [DataMember]
        public Decimal APROVAL_STATUS { get; set; }

        [DataMember]
        public String STATUS_NAME { get; set; }

        [DataMember]
        public Decimal REVISED_TARGET_VALUE { get; set; }

        [DataMember]
        public String COMMENTS { get; set; }

        [DataMember]
        public String REVISION_VALID_UP_TO { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_DISTRIBUTOR_TARGET entity = new SP_GET_DISTRIBUTOR_TARGET();

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
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[7]);

            if (values[8].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[8]);

            if (values[9].GetType() != typeof(System.DBNull))
                entity.TARGET_VALUE = Convert.ToDecimal(values[9]);

            if (values[10].GetType() != typeof(System.DBNull))
                entity.ACHIVED_VALUE = Convert.ToDecimal(values[10]);

            if (values[11].GetType() != typeof(System.DBNull))
                entity.TARGET_DETAIL_VERSION = Convert.ToDecimal(values[11]);

            if (values[12].GetType() != typeof(System.DBNull))
                entity.TARGET_DETAIL_ID = Convert.ToDecimal(values[12]);

            if (values[13].GetType() != typeof(System.DBNull))
                entity.APROVAL_STATUS = Convert.ToDecimal(values[13]);

            if (values[14].GetType() != typeof(System.DBNull))
                entity.STATUS_NAME = Convert.ToString(values[14]);

            if (values[15].GetType() != typeof(System.DBNull))
                entity.REVISED_TARGET_VALUE = Convert.ToDecimal(values[15]);

            if (values[16].GetType() != typeof(System.DBNull))
                entity.COMMENTS = Convert.ToString(values[16]);

            if (values[17].GetType() != typeof(System.DBNull))
                entity.REVISION_VALID_UP_TO = Convert.ToString(values[17]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
