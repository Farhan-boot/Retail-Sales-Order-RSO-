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
    public class GET_ROUTE_LIST : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String LAST_LIFTING { get; set; }

        [DataMember]
        public String RETAILER_NAME { get; set; }



        public object MapToEntity(object[] values)
        {
            GET_ROUTE_LIST entity = new GET_ROUTE_LIST();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.LAST_LIFTING = Convert.ToString(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RETAILER_NAME = Convert.ToString(values[1]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
