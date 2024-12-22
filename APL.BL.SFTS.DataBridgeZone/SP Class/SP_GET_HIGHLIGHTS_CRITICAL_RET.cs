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
    public class SP_GET_HIGHLIGHTS_CRITICAL_RET : ObjectMakerFromOracleSP.ISpClassEntity
    {       
        [DataMember]
        public String CRITICAL_TYPE { get; set; }

        [DataMember]
        public Decimal RETAILER_COUNT { get; set; }
         
      
        public object MapToEntity(object[] values)
        {
            SP_GET_HIGHLIGHTS_CRITICAL_RET entity = new SP_GET_HIGHLIGHTS_CRITICAL_RET();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.CRITICAL_TYPE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_COUNT = Convert.ToDecimal(values[1]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }      
}
