using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_RSO_TARGET_ACHIVEMENT : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String ITEM_NAME { get; set; }

        [DataMember]
        public String TARGET_PERIOD { get; set; }

        [DataMember]
        public Decimal MONTH_NO { get; set; }

        [DataMember]
        public Decimal TARGET_VALUE { get; set; }
        
        [DataMember]
        public Decimal ACHIVED_VALUE { get; set; }

        [DataMember]
        public Decimal PRO_RATED_TARGET { get; set; }

        [DataMember]
        public Decimal CURRENT_RR { get; set; }

        [DataMember]
        public Decimal REQUIRED_RR { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_RSO_TARGET_ACHIVEMENT entity = new SP_GET_RSO_TARGET_ACHIVEMENT();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ITEM_NAME = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.TARGET_PERIOD = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MONTH_NO = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.TARGET_VALUE = Convert.ToDecimal(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.ACHIVED_VALUE = Convert.ToDecimal(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.PRO_RATED_TARGET = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.CURRENT_RR = Convert.ToDecimal(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.REQUIRED_RR = Convert.ToDecimal(values[7]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
