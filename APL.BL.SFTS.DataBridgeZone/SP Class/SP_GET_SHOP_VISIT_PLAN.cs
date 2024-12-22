using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_SHOP_VISIT_PLAN : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal PLAN_ID { get; set; }

        [DataMember]
        public Decimal CENTER_ID { get; set; }    
                   
        [DataMember]
        public String CENTER_CODE { get; set; }  
           
        [DataMember]
        public String CENTER_NAME { get; set; } 
             
        [DataMember]
        public String CENTER_ADDRESS { get; set; }

        [DataMember]
        public Decimal STATUS_ID { get; set; }

        [DataMember]
        public String STATUS_NAME { get; set; }

        [DataMember]
        public Decimal LAT_VALUE { get; set; }

        [DataMember]
        public Decimal LONG_VALUE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_SHOP_VISIT_PLAN entity = new SP_GET_SHOP_VISIT_PLAN();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PLAN_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CENTER_ID = Convert.ToDecimal(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.CENTER_CODE = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.CENTER_NAME = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.CENTER_ADDRESS = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.STATUS_ID = Convert.ToDecimal(values[5]);
            if (values[6].GetType() != typeof(System.DBNull))
                entity.STATUS_NAME = Convert.ToString(values[6]);
            if (values[7].GetType() != typeof(System.DBNull))
                entity.LAT_VALUE = Convert.ToDecimal(values[7]);
            if (values[8].GetType() != typeof(System.DBNull))
                entity.LONG_VALUE = Convert.ToDecimal(values[8]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
