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
    public class SP_INS_RETURNEDSIMcls : ObjectMakerFromOracleSP.ISpClassEntity
    {
        [DataMember]
        public String PRODUCTCODE { get; set; }

        [DataMember]
        public String PARSEFILE { get; set; }

        [DataMember]
        public Decimal CCODE { get; set; }

        [DataMember]
        public DateTime EXITDATE { get; set; }

        [DataMember]
        public String SERIAL { get; set; }

        [DataMember]
        public DateTime LOADDATE { get; set; }

        public object MapToEntity(object[] values)
        {
            SP_INS_RETURNEDSIMcls entity = new SP_INS_RETURNEDSIMcls();

            if (values[0].GetType() != typeof(System.DBNull))
                entity.PRODUCTCODE = Convert.ToString(values[0]);
            if (values[1].GetType() != typeof(System.DBNull))
                entity.PARSEFILE = Convert.ToString(values[1]);
            if (values[2].GetType() != typeof(System.DBNull))
                entity.CCODE = Convert.ToDecimal(values[2]);
            if (values[3].GetType() != typeof(System.DBNull))
                entity.EXITDATE = Convert.ToDateTime(values[3]);
            if (values[4].GetType() != typeof(System.DBNull))
                entity.SERIAL = Convert.ToString(values[4]);
            if (values[5].GetType() != typeof(System.DBNull))
                entity.LOADDATE = Convert.ToDateTime(values[5]);

            return entity;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
