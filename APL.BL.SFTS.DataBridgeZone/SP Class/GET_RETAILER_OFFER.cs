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
    public class GET_RETAILER_OFFER: ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String OFFER_ID { get; set; }

        [DataMember]
        public String OFFER_NAME { get; set; }

        [DataMember]
        public String OFFER_DETAIL { get; set; }
     

        public object MapToEntity(object[] values)
        {
            GET_RETAILER_OFFER entity = new GET_RETAILER_OFFER();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.OFFER_ID = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.OFFER_NAME = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.OFFER_DETAIL = Convert.ToString(values[2]);
                  
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
