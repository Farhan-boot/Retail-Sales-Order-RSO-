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
    public class SP_GET_PRO_CATEGORYcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public Decimal PRODFAMILYID { get; set; }

        [DataMember]
        public String PFCODE { get; set; }

        [DataMember]
        public Decimal CATEGORYID { get; set; }

        [DataMember]
        public String CATEGORYNAME { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_GET_PRO_CATEGORYcls entity = new SP_GET_PRO_CATEGORYcls();
            if (values[0].GetType() != typeof(System.DBNull))
                entity.PRODFAMILYID = Convert.ToDecimal(values[0]);

            if (values[1].GetType() != typeof(System.DBNull))
                entity.PFCODE = Convert.ToString(values[1]);

            if (values[2].GetType() != typeof(System.DBNull))
                entity.CATEGORYID = Convert.ToDecimal(values[2]);

            if (values[3].GetType() != typeof(System.DBNull))
                entity.CATEGORYNAME = Convert.ToString(values[3]);

            return entity;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
