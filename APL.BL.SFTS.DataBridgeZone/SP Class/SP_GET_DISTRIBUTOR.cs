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
    public class SP_GET_DISTRIBUTOR : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public String FATHER_NAME { get; set; }

        [DataMember]
        public String MOTHER_NAME { get; set; }
   

        public object MapToEntity(object[] values)
        {
            SP_GET_DISTRIBUTOR entity = new SP_GET_DISTRIBUTOR();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[0]);
            
            if (values[1].GetType() != typeof(System.DBNull))
                entity.FATHER_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.MOTHER_NAME = Convert.ToString(values[2]);
         
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
