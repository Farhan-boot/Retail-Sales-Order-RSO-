using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_AMBM_SHOP_VISIT : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public Decimal CENTER_ID { get; set; }

        [DataMember]
        public String CENTER_CODE { get; set; }

        [DataMember]
        public String CENTER_NAME { get; set; }

        [DataMember]
        public String CENTER_ADDRESS { get; set; }

        [DataMember]
        public String VISITED_DATE { get; set; }

        [DataMember]
        public String VISITED_BY { get; set; }

        [DataMember]
        public String ACNOWLEDGE_STATUS { get; set; }
        
        public object MapToEntity(object[] values)
        {
            SP_GET_AMBM_SHOP_VISIT entity = new SP_GET_AMBM_SHOP_VISIT();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CENTER_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.CENTER_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.CENTER_NAME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.CENTER_ADDRESS = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.VISITED_DATE = Convert.ToString(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.VISITED_BY = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.ACNOWLEDGE_STATUS = Convert.ToString(values[7]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
