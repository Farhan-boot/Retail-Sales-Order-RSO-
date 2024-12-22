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
    public class SP_GET_STAFF_TARGET_DETAIL : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal ID { get; set; }

        [DataMember]
        public String RSO_CODE { get; set; }

        [DataMember]
        public String RSO_NAME { get; set; }

        [DataMember]
        public String TERRITORY { get; set; }

        [DataMember]
        public Decimal TARGET_VALUE { get; set; }

        [DataMember]
        public Decimal TARGET_VALUE_FOR_REVISE { get; set; }

        [DataMember]
        public String COMMENTS { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_STAFF_TARGET_DETAIL entity = new SP_GET_STAFF_TARGET_DETAIL();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.ID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.RSO_CODE = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.RSO_NAME = Convert.ToString(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.TERRITORY = Convert.ToString(values[3]);

            if (values[4].GetType() != typeof(System.DBNull))
                entity.TARGET_VALUE = Convert.ToDecimal(values[4]);

            if (values[5].GetType() != typeof(System.DBNull))
                entity.TARGET_VALUE_FOR_REVISE = Convert.ToDecimal(values[5]);

            if (values[6].GetType() != typeof(System.DBNull))
                entity.COMMENTS = Convert.ToString(values[6]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
