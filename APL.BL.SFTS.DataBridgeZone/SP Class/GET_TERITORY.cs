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
    public class GET_TERITORY : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public Decimal TERITORY_ID { get; set; }

        [DataMember]
        public String TERITORY_NAME { get; set; }

        public object MapToEntity(object[] values)
        {
            GET_TERITORY entity = new GET_TERITORY();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.TERITORY_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.TERITORY_NAME = Convert.ToString(values[1]);

           
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
