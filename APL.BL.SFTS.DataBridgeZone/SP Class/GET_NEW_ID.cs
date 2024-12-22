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
    public class GET_NEW_ID : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal NEW_ID { get; set; }

      
        public object MapToEntity(object[] values)
        {
            GET_NEW_ID entity = new GET_NEW_ID();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.NEW_ID = Convert.ToDecimal(values[0]);
          
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
