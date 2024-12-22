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
    public class GET_IS_VALID_TARGET_FOR : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String VALID_TARGET_FOR_CODE { get; set; }
      
        public object MapToEntity(object[] values)
        {
            GET_IS_VALID_TARGET_FOR entity = new GET_IS_VALID_TARGET_FOR();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.VALID_TARGET_FOR_CODE = Convert.ToString(values[0]);
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
