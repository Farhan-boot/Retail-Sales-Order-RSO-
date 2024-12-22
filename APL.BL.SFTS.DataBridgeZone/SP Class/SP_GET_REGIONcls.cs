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
    public class SP_GET_REGIONcls : ObjectMakerFromOracleSP.ISpClassEntity
    {     
        [DataMember]
        public Decimal REGION_ID { get; set; }


        [DataMember]
        public String REGION_CODE { get; set; }


        [DataMember]
        public String REGION_NAME { get; set; }

        [DataMember]
        public String REGION_NAME_CODE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_REGIONcls entity = new SP_GET_REGIONcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.REGION_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.REGION_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.REGION_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.REGION_NAME_CODE = Convert.ToString(values[3]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
