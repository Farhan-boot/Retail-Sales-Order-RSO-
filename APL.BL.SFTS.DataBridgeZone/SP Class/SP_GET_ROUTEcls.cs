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
    public class SP_GET_ROUTEcls : ObjectMakerFromOracleSP.ISpClassEntity
    {

        [DataMember]
        public Decimal ROUTE_ID { get; set; }

        [DataMember]
        public String ROUTENAME { get; set; }

        [DataMember]
        public String DESCRIPTION { get; set; }

        [DataMember]
        public String ROUTELENGTH { get; set; }

        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }

        [DataMember]
        public String ROUTE_CODE { get; set; }

        [DataMember]
        public String ROUTENAME_CODE { get; set; }


        public object MapToEntity(object[] values)
        {
            SP_GET_ROUTEcls entity = new SP_GET_ROUTEcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ROUTE_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.ROUTENAME = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.DESCRIPTION = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.ROUTELENGTH = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.ROUTE_CODE = Convert.ToString(values[5]);
           
            if (values[6].GetType() != typeof(System.DBNull))
                entity.ROUTENAME_CODE = Convert.ToString(values[6]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
