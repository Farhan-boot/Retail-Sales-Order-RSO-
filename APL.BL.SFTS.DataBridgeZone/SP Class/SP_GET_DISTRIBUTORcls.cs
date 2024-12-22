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
    public class SP_GET_DISTRIBUTORcls : ObjectMakerFromOracleSP.ISpClassEntity
    {     
        [DataMember]
        public Decimal DISTRIBUTOR_ID { get; set; }


        [DataMember]
        public String DISTRIBUTOR_CODE { get; set; }


        [DataMember]
        public String DISTRIBUTOR_NAME { get; set; }

        [DataMember]
        public String DISTRIBUTOR_NAME_CODE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_DISTRIBUTORcls entity = new SP_GET_DISTRIBUTORcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_ID = Convert.ToDecimal(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_CODE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME = Convert.ToString(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.DISTRIBUTOR_NAME_CODE = Convert.ToString(values[3]);
            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
