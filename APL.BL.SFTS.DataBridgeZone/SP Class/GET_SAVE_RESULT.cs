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
    public class GET_SAVE_RESULT : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal SAVE_RESULT_ID { get; set; }

      
        public object MapToEntity(object[] values)
        {
            GET_SAVE_RESULT entity = new GET_SAVE_RESULT();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.SAVE_RESULT_ID = Convert.ToDecimal(values[0]);
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
