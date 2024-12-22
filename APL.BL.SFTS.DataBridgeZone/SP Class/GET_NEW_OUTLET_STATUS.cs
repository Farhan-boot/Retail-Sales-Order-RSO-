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
    public class GET_NEW_OUTLET_STATUS : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String REQUEST_DATE { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }

        [DataMember]
        public String STATUS { get; set; }


        public object MapToEntity(object[] values)
        {
            GET_NEW_OUTLET_STATUS entity = new GET_NEW_OUTLET_STATUS();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.REQUEST_DATE = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.STATUS = Convert.ToString(values[2]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
