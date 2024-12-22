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
    public class SP_GET_CURRENT_OFFER : ObjectMakerFromOracleSP.ISpClassEntity
    {       
        [DataMember]
        public Decimal CURRENT_OFFER_ID { get; set; }

        [DataMember]
        public String OFFER_NAME { get; set; }

        [DataMember]
        public String OFFER_DETAIL { get; set; }

        [DataMember]
        public String START_DATE { get; set; }

        [DataMember]
        public String END_DATE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_CURRENT_OFFER entity = new SP_GET_CURRENT_OFFER();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.CURRENT_OFFER_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.OFFER_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.OFFER_DETAIL = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.START_DATE = Convert.ToString(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.END_DATE = Convert.ToString(values[4]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }      
}
