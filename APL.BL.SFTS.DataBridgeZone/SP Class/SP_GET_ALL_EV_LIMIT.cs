using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.SP_Class
{


    [Serializable()]
    [DataContract]
    public class SP_GET_ALL_EV_LIMIT : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal EV_LIMIT_ID { get; set; }

        [DataMember]
        public String EV_LIMIT_MIN_AMOUNT { get; set; }

        [DataMember]
        public String EV_LIMIT_MAX_AMOUNT { get; set; }

        

        public object MapToEntity(object[] values)
        {
            SP_GET_ALL_EV_LIMIT entity = new SP_GET_ALL_EV_LIMIT();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.EV_LIMIT_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.EV_LIMIT_MIN_AMOUNT = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.EV_LIMIT_MAX_AMOUNT = Convert.ToString(values[2]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
