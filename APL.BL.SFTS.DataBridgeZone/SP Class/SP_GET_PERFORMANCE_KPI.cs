using System;
using System.Runtime.Serialization;

namespace APL.BL.SFTS.DataBridgeZone
{
    [Serializable()]
    [DataContract]
    public class SP_GET_PERFORMANCE_KPI : ObjectMakerFromOracleSP.ISpClassEntity
    {              
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String CODE { get; set; }

        [DataMember]
        public String DESCRIPTION { get; set; }

       

        public object MapToEntity(object[] values)
        {
            SP_GET_PERFORMANCE_KPI entity = new SP_GET_PERFORMANCE_KPI();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DESCRIPTION = Convert.ToString(values[2]);          

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
