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
    public class SP_GET_USER_ROLE_RIGHTcls : ObjectMakerFromOracleSP.ISpClassEntity
    {        
        [DataMember]
        public Decimal ROLE_ID { get; set; }

        [DataMember]
        public Decimal USERINFO_ID { get; set; }

        [DataMember]
        public Decimal RIGHT_ID { get; set; }
        
        public object MapToEntity(object[] values)
        {
            SP_GET_USER_ROLE_RIGHTcls entity = new SP_GET_USER_ROLE_RIGHTcls();
           
            if (values[0].GetType() != typeof(System.DBNull))
                entity.ROLE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.USERINFO_ID = Convert.ToDecimal(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.RIGHT_ID = Convert.ToDecimal(values[2]);          

            return entity;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
