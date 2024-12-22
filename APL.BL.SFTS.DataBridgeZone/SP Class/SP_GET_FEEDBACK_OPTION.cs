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
    public class SP_GET_FEEDBACK_OPTION : ObjectMakerFromOracleSP.ISpClassEntity
    {       
        [DataMember]
        public Decimal FEEDBACK_OPTION_ID { get; set; }

        [DataMember]
        public String OPTION_TEXT { get; set; }
       

        public object MapToEntity(object[] values)
        {
            SP_GET_FEEDBACK_OPTION entity = new SP_GET_FEEDBACK_OPTION();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.FEEDBACK_OPTION_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.OPTION_TEXT = Convert.ToString(values[1]);
           
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }      
}
