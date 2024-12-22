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
    public class GET_REGION : ObjectMakerFromOracleSP.ISpClassEntity
    {      
        [DataMember]
        public Decimal REGION_ID { get; set; }

        [DataMember]
        public String REGION_NAME { get; set; }


        [DataMember]
        public Decimal Id { get; set; }

        [DataMember]
        public string Label { get; set; }


        public object MapToEntity(object[] values)
        {
            GET_REGION entity = new GET_REGION();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.REGION_ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.REGION_NAME = Convert.ToString(values[1]);

            if (values[0].GetType() != typeof(System.DBNull))
                entity.Id = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.Label = Convert.ToString(values[1]);


            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
