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
    public class SP_GET_VISIT_PLAN_SUMMARY : ObjectMakerFromOracleSP.ISpClassEntity
    {       
        [DataMember]
        public Decimal STATUS_ID { get; set; }

        [DataMember]
        public String STATUS_NAME { get; set; }

        [DataMember]
        public String IS_SIM_SALLER { get; set; }

        [DataMember]
        public Decimal TOTAL { get; set; }

      
        public object MapToEntity(object[] values)
        {
            SP_GET_VISIT_PLAN_SUMMARY entity = new SP_GET_VISIT_PLAN_SUMMARY();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.STATUS_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.STATUS_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.IS_SIM_SALLER = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.TOTAL = Convert.ToDecimal(values[3]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }      
}
